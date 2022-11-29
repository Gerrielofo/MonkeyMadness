using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDoor : MonoBehaviour
{
    public Animator openDoor;
    [SerializeField] private AudioSource knockSound;
    // Start is called before the first frame update
    void Start()
    {
        openDoor = GetComponentInParent<Animator>();
        knockSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        knockSound.Play();
    }
}
