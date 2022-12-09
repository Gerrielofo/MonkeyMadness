using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class BallsManager : MonoBehaviour
{
    [Header("Pins")]
    #region
    public List<GameObject> pins = new List<GameObject>();
    public GameObject pin;
    public GameObject clonePin;
    public Transform[] spawnlocations;
    #endregion
    [Header("Balls")]
    #region
    public GameObject ball;
    public GameObject cloneBall;
    public Transform ballSpawnpoint;
    #endregion
    [Header("Placing pins")]
    #region
    public int pinIndex;
    public bool[] canRespawn;
    public int[] pinNumber;
    public int numberofpins;
    public bool candospawnpins;
    public bool restart;
    #endregion
    [Header("Points")]
    #region
    public bool strike;
    public bool spare;
    public bool previousStrike;

    public TMP_Text pointsTxt;
    public int roundNumber;
    public int pointsThisRound;
    public int pointTotal;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Balling"))
        {
            Destroy(other.gameObject);

            StartCoroutine(RespawnBall());
            for (int i = 0; i < pinIndex; i++)
            {
                pins[i].GetComponent<PinManager>().CheckPins();
            }

            RemoveNonStandingPins();
            GetPoints();

            restart = true;
            roundNumber++;
        }
    }
    private void Start()
    {
        roundNumber = 1;
        RoundStartPins();
        SpawnBall();
    }
    public void RoundStartPins()
    {
        for (int i = 0; i < spawnlocations.Length; i++)
        {
            pinIndex++;
            clonePin = PhotonNetwork.Instantiate("Pin", spawnlocations[i].position, Quaternion.identity);
            pins.Add(clonePin);
        }
    }
    public void BetweenRoundPins(int pinNumber)
    {
        if (canRespawn[pinNumber])
        {
            clonePin = PhotonNetwork.Instantiate("Pin", spawnlocations[pinNumber].position, Quaternion.identity);
            pinIndex++;
            pins.Add(clonePin);
        }
    }
    public void SpawnBall()
    {
        cloneBall = PhotonNetwork.Instantiate("Bowlingbal", ballSpawnpoint.position, Quaternion.identity);
    }
    public IEnumerator RespawnPins()
    {
        yield return new WaitForSeconds(3);

        if (roundNumber >= 3 || strike)
        {
            RoundStartPins();

            roundNumber = 1;

            candospawnpins = false;

            if (strike)
            {
                strike = false;
            }
        }

        if (candospawnpins && roundNumber != 3)
        {
            for (int i = 0; i < pinNumber.Length; i++)
            {
                BetweenRoundPins(i);

                if (i == pinNumber.Length - 1)
                {
                    candospawnpins = false;
                }
            }
        }
    }
    public IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(3);

        SpawnBall();
    }
    private void Update()
    {
        if (strike)
        {
            StartCoroutine(RespawnPins());
        }
        if (restart)
        {
            restart = false;
            candospawnpins = true;
            StartCoroutine(RespawnPins());
        }
    }
    public void GetPoints()
    {
        for (int i = 0; i < canRespawn.Length; i++)
        {
            if (!canRespawn[i])
            {
                pointsThisRound++;
            }
            
            if (roundNumber == 1)
            {
                if (pointsThisRound == 10)
                {
                    strike = true;
                    GetPointTotal();
                    Debug.Log("strike");
                }
            }
            else
            {
                if (pointsThisRound == 10)
                {
                    spare = true;
                    GetPointTotal();
                    Debug.Log("spare");
                }
            }
        }
        if (roundNumber >= 2)
        {
            GetPointTotal();
        }
    }
    public void GetPointTotal()
    {
        if (previousStrike)
        {
            previousStrike = false;
            pointsThisRound *= 2;
        }

        if (roundNumber >= 2 || strike)
        {
            spare = false;

            if (strike)
            {
                previousStrike = true;
            }

            Debug.Log(pointsThisRound);
            pointTotal += pointsThisRound;
            pointsThisRound = 0;
        }
        pointsTxt.text = "Points: " + pointTotal;
    }
    public void RemoveNonStandingPins()
    {
        for (int i = 0; i < pinIndex; i++)
        {
            if (pins[i].GetComponent<PinManager>().down)
            {
                Destroy(pins[i]);
                canRespawn[i] = false;
            }
            else
            {
                Destroy(pins[i]);
                pinNumber[i] = i;
                canRespawn[i] = true;
            }

            if (i == pinIndex - 1)
            {
                pinIndex = 0;

                pins.Clear();
            }
        }
    }
    public void DeletePins()
    {
        pinIndex = 0;
    }
}
