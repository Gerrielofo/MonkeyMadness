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
        PhotonNetwork.Instantiate("dartPijl", transform.position, transform.rotation);
    }
}
