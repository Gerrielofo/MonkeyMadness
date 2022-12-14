using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Bowlen : MonoBehaviour
{
    public Transform pinsBundelPos;
    public GameObject pinBundel;
    public float scoreThisRound;
    public float score;
    public bool frame2;
    private bool strikeLastRound;

    public void StartBowlen() {
        pinBundel = PhotonNetwork.Instantiate("pinBundel", pinsBundelPos.position, Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "BowlingBal") {
            UpdateScore();
        }
    }
    public void UpdateScore() {
        foreach (Transform child in pinBundel.transform) {
            //check pins die om zijn
            if (child.rotation.y != 0) {
                Destroy(child);
                scoreThisRound++;
                if (strikeLastRound) {
                    scoreThisRound++;
                }
            }
        }
        //reset strike als je strike had
        if (strikeLastRound) {
            strikeLastRound = false;
        }
        //Strike!!!
        if (scoreThisRound == 10 && !frame2) {
            strikeLastRound = true;
            frame2 = true;
        }
        //ronde 2 is over, tel score op en reset ronde score
        if (frame2) {
            //Spare!!!!
            if (scoreThisRound == 10 && !strikeLastRound) {
                
            }
            score += scoreThisRound;
            scoreThisRound = 0;
            ResetPins();
        }
        //volgende ronde als je geen strike hebt
        if (!frame2 && strikeLastRound == false) {
            frame2 = true;
            //volgende ronde
        }
    }
    public IEnumerator ResetPins() {
        yield return new WaitForSeconds(3);
        Destroy(pinBundel);
        yield return new WaitForSeconds(3);
        pinBundel = PhotonNetwork.Instantiate("pinBundel", pinsBundelPos.position, Quaternion.identity);
    }
}
