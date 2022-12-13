using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BowlenManager : MonoBehaviourPunCallbacks {
    public GameObject pinBundel;
    public Transform[] pinLocations;
    public Player[] playerList;
    // Start is called before the first frame update
    void Start()
    {
        playerList = PhotonNetwork.PlayerList;
        foreach (Player player in PhotonNetwork.PlayerList) {
            Debug.Log(player.NickName + ", User ID =" + player.UserId);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
