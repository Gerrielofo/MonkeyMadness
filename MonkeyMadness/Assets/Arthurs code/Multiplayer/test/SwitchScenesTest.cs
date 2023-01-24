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
    public static bool switchs = true;
    [PunRPC]
    public static IEnumerator SceneSwitch(string sceneToLoad) {
        yield return new WaitForSeconds(5);
        if (switchs)
        {
            Debug.Log(sceneToLoad);
            switchs = false;
            if (sceneToLoad != null)
            {
                
                PhotonNetwork.LoadLevel(sceneToLoad);
                sceneToLoad = null;
            }
            else
            {
                PhotonNetwork.LoadLevel(miniGameToLoad[sceneNumberToLoad]);
            }
        }
        
    }
}
