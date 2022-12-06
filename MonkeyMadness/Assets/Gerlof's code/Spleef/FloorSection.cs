using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSection : MonoBehaviour
{
    private Rigidbody Rigidbody;
    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Poop")
        {
            Rigidbody.useGravity = true;
            Rigidbody.constraints &= ~RigidbodyConstraints.FreezeAll;
            Destroy(gameObject, 3f);
            Destroy(collision.gameObject);
        }
    }
}
