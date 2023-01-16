using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballsmanagers : MonoBehaviour
{
    public BowlingGrabber grabber;
    public bool candotimer;
    public float timer;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("BowlingLane"))
        {
            candotimer = true;
        }
        else
        {
            candotimer = false;
        }
    }
    private void Update()
    {
        if (candotimer)
        {
            timer += Time.deltaTime;
            if (timer > 8)
            {
                candotimer = false;
                Destroy(grabber.bowlingBall);
            }
        }
    }
}
