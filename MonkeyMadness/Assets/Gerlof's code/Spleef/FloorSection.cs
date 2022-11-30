using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Poop")
        {
            GetComponent<Rigidbody>().useGravity = true;
            Destroy(gameObject, 3f);
        }
    }
}
