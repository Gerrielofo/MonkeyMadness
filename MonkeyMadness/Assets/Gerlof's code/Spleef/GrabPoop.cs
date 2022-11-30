using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPoop : MonoBehaviour
{
    [SerializeField] private GameObject poopPrefap;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Hands"))
        {

        }
    }


}
