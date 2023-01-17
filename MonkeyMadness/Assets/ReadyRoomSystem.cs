using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ReadyRoomSystem : MonoBehaviour
{
    public int playersIN;
    public bool canSwitch;
    [HideInInspector] static public string sceneToLoad;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IsPlayer"))
        {
            playersIN++;
            Debug.Log("Player entered ready room \n" + "Players in ready room is now: " + playersIN);
            Debug.Log("Players in room:" + PhotonNetwork.PlayerList.Length);
        }
        if (playersIN == PhotonNetwork.PlayerList.Length)
        {
            PhotonView.Get(this).RPC("sceneSwitch", RpcTarget.AllBuffered);
        }
    }
    [PunRPC]
    public void sceneSwitch()
    {
        Debug.Log("PLayers in ready room is now: " + playersIN);
        Debug.Log(PhotonNetwork.PlayerList.Length);
        Debug.Log("Can Switch = true");
        StartCoroutine(SwitchScenesTest.SceneSwitch(sceneToLoad));
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("IsPlayer"))
        {
            playersIN--;
            Debug.Log("Player left ready room \n" + "Players in ready room is now: " + playersIN);
            Debug.Log("Players in room:" + PhotonNetwork.PlayerList.Length);
        }
    }
}
