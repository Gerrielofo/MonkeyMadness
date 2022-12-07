using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SwitchScenesTest : MonoBehaviour
{
    public SpawnPlayers spawnPlayers;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2) {
            StartCoroutine(SceneSwitch());
        }
    }
    IEnumerator SceneSwitch() {
        yield return new WaitForSeconds(2);
        PhotonNetwork.LoadLevel("maykel");
        spawnPlayers.SpawnPlayer();
    }
}
