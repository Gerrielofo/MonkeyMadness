using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class BananaTagScript : MonoBehaviour {
    private PhotonView photonView;
    private bool cooldown;
    public Collider previouseHolder;
    public GameObject[] players;
    // Start is called before the first frame update
    void Start() {
        photonView = GetComponent<PhotonView>();
        
        players = GameObject.FindGameObjectsWithTag("IsPlayer");
        Collider other = players[Random.Range(0, PhotonNetwork.PlayerList.Length)].GetComponent<Collider>();
        GiveBanan(other);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("IsPlayer") && !cooldown && other != previouseHolder) {

            StartCoroutine(GiveBanan(other));
        }
    }
    IEnumerator GiveBanan(Collider other) {
        previouseHolder = other;
        cooldown = true;
        photonView.RequestOwnership();
        Transform bananholder = other.transform.parent.GetChild(2).GetChild(1);
        transform.position = bananholder.position;
        transform.parent = null;
        transform.position = bananholder.position;
        transform.parent = bananholder;
        transform.GetComponent<Rigidbody>().isKinematic = true;
        transform.GetComponent<Rigidbody>().useGravity = false;
        transform.GetComponent<BoxCollider>().isTrigger = true;
        transform.position = bananholder.position;
        yield return new WaitForSeconds(5);
        cooldown = false;
    }
}
