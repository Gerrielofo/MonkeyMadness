using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathmanager : MonoBehaviour
{
    public bool Spleef;
    private bool dead;


    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("IsPlayer") && Spleef)
        {
            SpleefManager.alive --;
        }
    }
}
