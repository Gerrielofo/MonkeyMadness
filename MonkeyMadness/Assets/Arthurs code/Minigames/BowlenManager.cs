using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class BowlenManager : MonoBehaviourPunCallbacks
{
    public Player[] players;
    public Transform[] baanLocatiesl;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdatePlayersListDelay());
    }
    public IEnumerator UpdatePlayersListDelay() {
        yield return new WaitForSeconds(5);
        UpdatePlayersList();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer) {
        base.OnPlayerEnteredRoom(newPlayer);
        UpdatePlayersList();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer) {
        base.OnPlayerLeftRoom(otherPlayer);
        UpdatePlayersList();
    }
    public void UpdatePlayersList() {
        foreach (Player player in PhotonNetwork.PlayerList) {
            players[i] = player;
            i++;
        }
    }
}
