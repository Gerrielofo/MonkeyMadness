using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnBanana : MonoBehaviour
{
    public PhotonView photonView;
    public bool spawned;
    private void Start() {
        StartCoroutine(BananaSpawnDelay());
    }
    [PunRPC]
    IEnumerator BananaSpawnDelay() {
        yield return new WaitForSeconds(3);
        Debug.Log("trying to spawn banana");
        if (!spawned) {
            photonView.RPC("SpawnBananaStart", RpcTarget.MasterClient);
        }
    }
    [PunRPC]
    void SpawnBananaStart() {
        PhotonNetwork.Instantiate("Bananabomb", transform.position, transform.rotation);
        spawned = true;
        Debug.Log("BananaSpawned");
    }
}
