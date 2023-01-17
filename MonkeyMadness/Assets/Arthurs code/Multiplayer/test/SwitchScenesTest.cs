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
    public static string[] miniGameToLoad;
    public int sceneToLoad;
    public bool canChange;
    public ReadyRoomSystem ready;
    // Update is called once per frame
    void Update()
    {
        if (ready.canSwitch && canChange)
        {
            ready.canSwitch = false;
            StartCoroutine(SceneSwitch(null, sceneToLoad));
            canChange = false;
        }
    }
    public static IEnumerator SceneSwitch(string roomToSwitchTo, int sceneToLoad) {
        yield return new WaitForSeconds(5);
        if (roomToSwitchTo == null) {
            PhotonNetwork.LoadLevel(roomToSwitchTo);
        }else{
            PhotonNetwork.LoadLevel(miniGameToLoad[sceneToLoad]);
        }
    }
}
