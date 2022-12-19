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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SwitchScene(int RoomSwitch) {
        print(RoomSwitch);
        if (maykel == false) {
            sceneToLoad = RoomSwitch;
            StartCoroutine(SceneSwitch());
            maykel = true;
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
