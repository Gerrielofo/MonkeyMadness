using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviourPunCallbacks {
    public GameObject spawnedPlayerPrefab;
    public GameObject ghostPrefab;
    public float minX, maxX, minY, maxY;
    private string playerName;
    private int playerNumber;
    public GameObject[] players;

    //Start is called before the first frame update
    private void Start() {
        SpawnPlayer();
    }

    public override void OnLeftRoom() {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
    public void SpawnPlayer() {
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
        playerName = PhotonNetwork.LocalPlayer.NickName;
        Debug.Log("Joined room");
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Vector2 fixedspawn = new Vector2(0, 0);
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", fixedspawn, Quaternion.identity);
        Debug.Log(spawnedPlayerPrefab.name);
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
    }
}
