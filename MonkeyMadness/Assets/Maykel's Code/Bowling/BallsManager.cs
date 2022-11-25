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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("balling"))
        {
            for (int i = 0; i < pinIndex; i++)
            {
                pins[i].GetComponent<PinManager>().CheckPins();
                print("hasChecked");
            }
            RemoveNonStandingPins();
        }
    }
    private void Start()
    {
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
                print(i);
            }
            else
            {
                Destroy(pins[i]);
                pinNumber[i] = i;
                canRespawn[i] = true;
                print(i);
            }

            if (i == pinIndex)
            {
                pinIndex = 0;
            }
        }
    }

    private void Update()
    {
        if (retard)
        {
            retard = false;
            StartCoroutine(Respawnpins());
        }
    }
    public IEnumerator Respawnpins()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < pinNumber.Length; i++)
        {
            SpawnPins(i);
        }
        
    }
    public void DeletePins()
    {
        pinIndex = 0;
    }
}
