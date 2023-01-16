using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingGrabber : MonoBehaviour
{
    public GameObject[] bowlingPrefabs;
    public GameObject bowlingBall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands") && other.GetComponent<XRDirectExtraInteractor>().heldItem == null && bowlingBall == null)
        {
            
            bowlingBall = Instantiate(bowlingPrefabs[Random.RandomRange(0,5)], transform.position, Quaternion.identity);
        }
        if (other.CompareTag("Resetter"))
        {
            Destroy(bowlingBall);
        }
    }
}
