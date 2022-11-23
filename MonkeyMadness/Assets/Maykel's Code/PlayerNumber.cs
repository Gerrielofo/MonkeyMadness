using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerNumber : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
