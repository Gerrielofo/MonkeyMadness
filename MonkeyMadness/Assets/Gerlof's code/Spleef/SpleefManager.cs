using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpleefManager : MonoBehaviour
{
    public static bool gameEnded;
    public static int alive;

    private void Start()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("GameSetup", RpcTarget.AllBuffered, "jup", "and jup.");
        alive = PhotonNetwork.PlayerList.Length;
    }
    void Update()
    {
        if (alive > 0)
            return;
        else
        {
            gameEnded = true;
        }
    }
    [PunRPC]
    void GameSetup()
    {

    }
}
