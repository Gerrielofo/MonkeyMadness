using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PointSystem : MonoBehaviour
{
    public int[] points;
    public GameObject[] monkey;
    public int[] placement;

    public int[] minigamePoints;
    public int firstplace;
    public int[] players;
    ExitGames.Client.Photon.Hashtable playerInfo = new ExitGames.Client.Photon.Hashtable();
    private void Start()
    {
        // OPSLAAN
        
        playerInfo["pointsP" + PhotonNetwork.LocalPlayer.UserId] = points[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];
        playerInfo["monkeyP" + PhotonNetwork.LocalPlayer.UserId] = monkey[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];
        playerInfo["placementP" + PhotonNetwork.LocalPlayer.UserId] = placement[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];
        playerInfo["minigameP" + PhotonNetwork.LocalPlayer.UserId] = minigamePoints[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];
    }
    private void Update()
    {
        // vergelijk player id met player die eerste die geworden
    }
    public void CalculateBananaTag()
    {
        playerInfo["minigameP" + PhotonNetwork.LocalPlayer.UserId] = placement[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];


    }
    public void CalculateBowling()
    {
        Array.Reverse(minigamePoints);
        playerInfo["minigameP" + PhotonNetwork.LocalPlayer.UserId] = placement[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];
    }
    public void CalculatePlacement()
    {
        Array.Sort(minigamePoints);
    }
    public void CalculatePoints()
    {
        playerInfo["pointsP" + PhotonNetwork.LocalPlayer.UserId] =+ placement[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];
    }
}
