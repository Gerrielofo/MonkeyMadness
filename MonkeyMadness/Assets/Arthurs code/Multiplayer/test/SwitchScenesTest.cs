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
    public static int sceneNumberToLoad;
    [PunRPC]
    public static IEnumerator SceneSwitch(string sceneToLoad) {
        yield return new WaitForSeconds(5);
        if (sceneToLoad != null) {
            PhotonNetwork.LoadLevel(sceneToLoad);
        }else{
            PhotonNetwork.LoadLevel(miniGameToLoad[sceneNumberToLoad]);
        }
    }
}
