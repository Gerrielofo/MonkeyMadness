using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopGrab : MonoBehaviour
{
    [SerializeField] private GameObject poopPrefap;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands") && other.GetComponent<XRDirectExtraInteractor>().heldItem != null)
        {
            GameObject poop = (GameObject)Instantiate(poopPrefap, transform.position, transform.rotation);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
