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
    public static string test;
    [HideInInspector] static public string sceneToLoad;
    [PunRPC]
    public static IEnumerator SceneSwitch() {
        test = "kaas";
        yield return new WaitForSeconds(3);
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
