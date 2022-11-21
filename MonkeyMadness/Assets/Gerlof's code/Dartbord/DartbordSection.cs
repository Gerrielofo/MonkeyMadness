using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartbordSection : MonoBehaviour
{
    public int minigameID;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Dart")
        {
            print(minigameID);
        }
    }
}
