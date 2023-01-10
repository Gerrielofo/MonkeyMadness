using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSection : MonoBehaviour
{
    private Rigidbody Rigidbody;
    [SerializeField] private GameObject poopSplatter;
    [SerializeField] private float dropDelay = 1;
    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (SpleefManager.gameEnded)
            return;
        if(collision.transform.tag == "IsPlayer")
        {
            StartCoroutine(DropBlock());
        }
        else if(collision.transform.tag == "Poop")
        {
            Instantiate(poopSplatter, collision.transform.position, collision.transform.rotation);
            Rigidbody.useGravity = true;
            Rigidbody.constraints &= ~RigidbodyConstraints.FreezeAll;
            Destroy(gameObject, 3f);
            Destroy(collision.gameObject);
        }
    }

    IEnumerator DropBlock()
    {
        yield return new WaitForSeconds(dropDelay);
        Rigidbody.useGravity = true;
        Rigidbody.constraints &= ~RigidbodyConstraints.FreezeAll;
        Destroy(gameObject, 3f);
    }
}
