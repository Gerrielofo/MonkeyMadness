using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [Header("Input fields", order = 0)]
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public TMP_InputField playerName;
    [Header("Room Options", order = 1)]
    public float maxPlayers;
    public void CreateRoom() {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LocalPlayer.NickName = playerName.text;
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)maxPlayers;
        Debug.Log("Creating room with name: " + createInput.text);
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom() {
        Debug.Log("Joining room with name: " + joinInput.text);
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel("Game");
    }
}
