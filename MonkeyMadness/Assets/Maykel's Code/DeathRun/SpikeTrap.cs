using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public void Spike()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("dead");
    }
}
