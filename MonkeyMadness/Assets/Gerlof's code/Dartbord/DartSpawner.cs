using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DartSpawner : MonoBehaviour
{
    [SerializeField] private GameObject dart;

    private void Start()
    {
        SpawnDart();
    }
    public void SpawnDart()
    {
        NetworkPlayer.Instantiate(dart, transform.position, transform.rotation);
    }
}
