using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDoor : MonoBehaviour
{
    public Animator openDoor;
    [SerializeField] private AudioSource knockSound;

    void Start()
    {
        openDoor = GetComponentInParent<Animator>();
        knockSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Hands")
        {
            knockSound.Play();
        }
    }
}
