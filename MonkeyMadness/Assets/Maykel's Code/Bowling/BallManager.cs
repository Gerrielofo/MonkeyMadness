using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public Transform spawnpoint;
    public Transform ball;
    public void RespawnBall()
    {
        ball = spawnpoint;
    }
}
