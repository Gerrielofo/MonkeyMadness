using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSection : MonoBehaviour
{
    private Rigidbody Rigidbody;
    [SerializeField] private GameObject poopSplatter;
    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Poop")
        {
            Instantiate(poopSplatter, collision.transform.position, collision.transform.rotation);
            Rigidbody.useGravity = true;
            Rigidbody.constraints &= ~RigidbodyConstraints.FreezeAll;
            Destroy(gameObject, 3f);
            Destroy(collision.gameObject);
        }
    }
}
