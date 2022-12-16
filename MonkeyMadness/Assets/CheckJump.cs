using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckJump : MonoBehaviour
{
    public GameObject prov;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            print("hhyg");
            prov.GetComponent<ExpandedMovementProvider>().canJump = true;
        }
    }
}
