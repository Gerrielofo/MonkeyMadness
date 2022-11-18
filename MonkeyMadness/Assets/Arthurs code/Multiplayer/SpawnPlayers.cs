using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject spawnedPlayerPrefab;
    public float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    private void Start() {
        Debug.Log("Joined room");
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Vector2 fixedspawn = new Vector2(10, 10);
        spawnedPlayerPrefab = PhotonNetwork.Instantiate(spawnedPlayerPrefab.name, fixedspawn, Quaternion.identity);
        Debug.Log(spawnedPlayerPrefab.name);
    }
    public override void OnLeftRoom() {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
