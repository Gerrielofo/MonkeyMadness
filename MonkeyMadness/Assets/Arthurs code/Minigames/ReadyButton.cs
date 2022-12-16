using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ReadyButton : MonoBehaviourPunCallbacks
{
    public Transform[] bowlingBanen;
    public GameObject[] baanSpeler;
    public ButtenInVr button;
    private int i;
    public void SpelerWilBowlen() {
        button.presser.transform.position = bowlingBanen[i].position;
        button.presser = baanSpeler[i];
        i++;
        if (i >= PhotonNetwork.PlayerList.Length) {
            
        }
    }
}
