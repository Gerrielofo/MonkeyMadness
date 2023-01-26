using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 starsOffset;
    [SerializeField] private GameObject starsEffect;
    [SerializeField] private GameObject poopSplatter;
    private void OnCollisionEnter(Collision collision)
    {/*
        if (collision.transform.CompareTag("IsPlayer"))
        {
            if (collision.transform.GetComponent<ExpandedMovementProvider>().stunDelay <= 0)
            {
                collision.transform.GetComponent<ExpandedMovementProvider>().Stun();
                Instantiate(starsEffect, collision.transform.position + starsOffset, collision.transform.rotation * Quaternion.Euler(-90, 0, 0));
                Instantiate(poopSplatter, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        */
    }
}
