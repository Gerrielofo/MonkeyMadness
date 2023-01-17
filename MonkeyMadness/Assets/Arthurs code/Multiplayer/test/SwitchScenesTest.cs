using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class SwitchScenesTest : MonoBehaviour
{
    private bool maykel;
    public SpawnPlayers spawnPlayers;
    public InputField roomToSwitchTo;
    public bool autmaticSwitch;
    [Header("Choose Room")]
    public string[] miniGameToLoad;
    public int sceneToLoad;
    public bool canChange;
    public ReadyRoomSystem ready;
    // Update is called once per frame
    void Update()
    {
        if (ready.canSwitch && canChange)
        {
            ready.canSwitch = false;
            StartCoroutine(SceneSwitch());
            canChange = false;
        }
    }
    IEnumerator SceneSwitch() {
        yield return new WaitForSeconds(5);
        if (roomToSwitchTo == null) {
            PhotonNetwork.LoadLevel(miniGameToLoad[sceneToLoad]);
        } else {
            PhotonNetwork.LoadLevel(roomToSwitchTo.ToString());
        }
    }
}
