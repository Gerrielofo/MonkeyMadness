using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SwitchScenesTest : MonoBehaviour
{
    public bool maykel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && !maykel) {
            StartCoroutine(SceneSwitch());
            maykel = true;
        }
    }
    IEnumerator SceneSwitch() {
        yield return new WaitForSeconds(2);
        PhotonNetwork.LoadLevel("maykel");
    }
}
