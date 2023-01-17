using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ReadyRoomSystem : MonoBehaviour
{
    public int playersIN;
    public bool canSwitch;
    public PhotonView photonView;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if ()
        if (other.CompareTag("IsPlayer"))
        {
            playersIN++;
            Debug.Log("Player entered ready room \n" + "Players in ready room is now: " + playersIN);
            Debug.Log("Players in room:" + PhotonNetwork.PlayerList.Length);
        }
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
    private void Update()
    {
        if (playersIN == PhotonNetwork.PlayerList.Length)
        {
            Debug.Log("PLayers in ready room is now: " + playersIN);
            Debug.Log(PhotonNetwork.PlayerList.Length);
            Debug.Log("Can Switch = true");
            canSwitch = true;
        }
    }
}
