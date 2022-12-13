using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BowlenManager : MonoBehaviourPunCallbacks {
    public GameObject pinBundel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.Log(newPlayer.UserId);
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
