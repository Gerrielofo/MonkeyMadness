using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    public List<GameObject> pins = new List<GameObject>();

    public int pinIndex;
    public GameObject pin;
    public GameObject clonePin;

    public Transform[] spawnlocations;
    public bool[] canRespawn;

    //public List<int> pinNumber = new List<int>();
    public int[] pinNumber;

    public bool retard;

    public bool strike;
    public bool spare;

    public int roundNumber;

    public int numberofpins;

    public bool candospawnpins;

    public int pointsThisRound;

    public int pointTotal;

    public bool previousStrike;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("balling"))
        {
            
            for (int i = 0; i < pinIndex; i++)
            {
                pins[i].GetComponent<PinManager>().CheckPins();
            }

            RemoveNonStandingPins();
            GetPoints();

            retard = true;
            roundNumber++;
        }
    }

    private void Start()
    {
        roundNumber = 1;
        StartSpawnPins();
    }
    public void StartSpawnPins()
    {
        for (int i = 0; i < spawnlocations.Length; i++)
        {
            pinIndex++;
            clonePin = Instantiate(pin, spawnlocations[i]);
            pins.Add(clonePin);
        }
    }

    public void SpawnPins(int pinNumber)
    {
        if (canRespawn[pinNumber])
        {
            clonePin = Instantiate(pin, spawnlocations[pinNumber]);
            pinIndex++;
            pins.Add(clonePin);
        }
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

    private void Update()
    {
        if (strike)
        {
            StartCoroutine(Respawnpins());
        }
        if (retard)
        {
            retard = false;
            candospawnpins = true;
            StartCoroutine(Respawnpins());
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
            previousStrike = true;
            Debug.Log(pointsThisRound);
            pointTotal += pointsThisRound;
            pointsThisRound = 0;
        }
    }
    public IEnumerator Respawnpins()
    {
        yield return new WaitForSeconds(3);

        if (roundNumber >= 3 || strike)
        {
            StartSpawnPins();

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
                SpawnPins(i);

                if (i == pinNumber.Length - 1)
                {
                    candospawnpins = false;
                }
            }
        }
    }
    public void DeletePins()
    {
        pinIndex = 0;
    }
}
