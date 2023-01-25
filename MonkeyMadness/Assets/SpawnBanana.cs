using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnBanana : MonoBehaviour
{
    public PhotonView photonView;
    private void Start() {
        StartCoroutine(BananaSpawnDelay());
    }
    IEnumerator BananaSpawnDelay() {
        yield return new WaitForSeconds(3);
        Debug.Log("trying to spawn banana");
        photonView.RPC("SpawnBananaStart", RpcTarget.MasterClient);
    }
    void SpawnBananaStart() {
        PhotonNetwork.Instantiate("Bananabomb", transform.position, transform.rotation);
        Debug.Log("BananaSpawned");
    }
}
