using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnBanana : MonoBehaviour
{
    public PhotonView photonView;
    private void Start() {
        photonView.RPC("SpawnBananaStart", RpcTarget.MasterClient);
    }
    void SpawnBananaStart() {
        PhotonNetwork.Instantiate("Bananabomb", transform.position, transform.rotation);
    }
}
