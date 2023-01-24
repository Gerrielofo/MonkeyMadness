using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    private Rigidbody Rigidbody;
    private DartSpawner DartSpawner;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        DartSpawner = GameObject.Find("DartSpawner").GetComponent<DartSpawner>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Dartbord")
        {
            Debug.Log(collision.transform.tag);
            Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
        else if(collision.transform.tag != "Table" && collision.transform.tag != "Darbord" && collision.transform.tag != "Dart")
        {
            DartSpawner.SpawnDart();
            Destroy(gameObject);
        }
    }
}
