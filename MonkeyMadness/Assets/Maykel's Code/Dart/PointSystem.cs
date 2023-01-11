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

    public List<int> minigamePoints;
    public int firstplace;

    public int[] players;
    private int pm;

    public PhotonView photonView;

    public List<int> tList;
    public bool kaas;
    public IDictionary<int, int> playerPoints;
    ExitGames.Client.Photon.Hashtable playerInfo = new ExitGames.Client.Photon.Hashtable();
    public void Start()
    {
        // OPSLAAN
        //Debug.Log(Int32.Parse(PhotonNetwork.LocalPlayer.UserId));
        IDictionary<int, int> playerPoint = new Dictionary<int, int>();
        playerPoint.Add(1, 12);
        playerPoint.Add(2, 40);
        playerPoint.Add(3, 3);
        playerPoint.Add(4, 10);
        playerPoints = playerPoint;
        Placement();
        /*
        playerInfo["pointsP" + PhotonNetwork.LocalPlayer.UserId] = points[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];
        playerInfo["monkeyP" + PhotonNetwork.LocalPlayer.UserId] = monkey[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];
        playerInfo["placementP" + PhotonNetwork.LocalPlayer.UserId] = placement[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];
        playerInfo["minigameP" + PhotonNetwork.LocalPlayer.UserId] = minigamePoints[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];
        */
    }
    public void AddPoints(int points, int userId) {
        playerPoints[userId] = points;
    }
    public void Placement(){
        var ordered = playerPoints.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        foreach (KeyValuePair<int, int> kvp in ordered.Reverse()) {
            Debug.Log(kvp.Key.ToString() + kvp.Value.ToString());
        }
    }
    public void Update()
    {
        // vergelijk player id met player die eerste die geworden

        //uncomment na testen
        //var tList = new List<int>();
        //tList = minigamePoints.ToList();



        //for (int i = 0; i < tList.ToArray().Length; i++)
        //{
        //    if(tList.ToArray()[i] == tList.ToArray().Max())
        //    {
        //        placement[pm] = tList.ToArray()[i];
        //        pm++;
        //        tList.Remove(i);
        //        i = 0;
        //    }
        //}
        //if (!kaas)
        //{
        //    Debug.Log(placement.ToString());
        //    kaas = true;
        //}
    }
    public void CalculateBananaTag()
    {
        playerInfo["minigameP" + PhotonNetwork.LocalPlayer.UserId] = placement[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];


    }
    public void CalculateBowling()
    {
        playerInfo["minigameP" + PhotonNetwork.LocalPlayer.UserId] = placement[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];
    }
    public void CalculatePlacement()
    {
    }
    public void CalculatePoints()
    {
        playerInfo["pointsP" + PhotonNetwork.LocalPlayer.UserId] = +placement[Int32.Parse(PhotonNetwork.LocalPlayer.UserId)];
    }
}
