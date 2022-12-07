using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 starsOffset;
    [SerializeField] private GameObject starsEffect;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("IsPlayer"))
        {
            collision.transform.GetComponent<ExpandedMovementProvider>().Stun();
            GameObject stars = (GameObject)Instantiate(starsEffect, collision.transform.position + starsOffset, collision.transform.rotation * Quaternion.Euler(-90, 0, 0));
            Destroy(gameObject);
            Destroy(stars, collision.transform.GetComponent<ExpandedMovementProvider>().stunTime);
        }
    }
}
