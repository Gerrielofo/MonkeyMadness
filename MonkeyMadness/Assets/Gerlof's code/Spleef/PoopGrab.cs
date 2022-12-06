using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopGrab : MonoBehaviour
{
    [SerializeField] private GameObject poopPrefap;
    private bool isInCollider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            GameObject poop = (GameObject)Instantiate(poopPrefap, transform.position, transform.rotation);
            //poop.GetComponent<MeshRenderer>().enabled = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
