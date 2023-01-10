using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class ReadyRoomSystem : MonoBehaviour
{
    public int playersIN;
    public bool canSwitch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IsPlayer"))
        {
            playersIN++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("IsPlayer"))
        {
            playersIN--;
        }
    }
    private void Update()
    {
        if (playersIN == PhotonNetwork.PlayerList.Length)
        {
            canSwitch = true;
        }
    }
}
