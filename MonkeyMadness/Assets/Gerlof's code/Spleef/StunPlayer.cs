using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("IsPlayer"))
        {
            collision.transform.GetComponent<ExpandedMovementProvider>().Stun();
            Destroy(gameObject);
        }
    }
}
