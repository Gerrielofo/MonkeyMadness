using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;
using Photon.Pun.UtilityScripts;
using Unity.XR.CoreUtils;

public class BananaTagScript : MonoBehaviour 
{
    private PhotonView photonView;
    public bool cooldown;
    public Collider previouseHolder;
    public Collider hit;
    public GameObject[] players;
    public float bombTime;
    public int explodeTime;
    public bool timerstart;
    private bool started;
    public bool spawned;
    private bool ended;
    private bool transferOnExplode;
    public Transform cage;
    public GameObject banana;
    //public PointSystem pointsustem;
    public int pointsOnExplode = 10;
    public int pointsExtraPerPosition;
    public Transform bananaholder;
    // Start is called before the first frame update
    void Start() {
        photonView = GetComponent<PhotonView>();
    }
    IEnumerator GiveBananaStart() {
        yield return new WaitForSeconds(3);
        Debug.Log("array length is" + players.Length);
        hit = players[UnityEngine.Random.Range(0, players.Length)].GetComponent<Collider>();
        SyncBanana();
        yield return null;
    }
    private void Update()
    {
        banana = GameObject.FindGameObjectWithTag("Banana");
        if (!started) {
            photonView = GetComponent<PhotonView>();
            players = GameObject.FindGameObjectsWithTag("IsPlayer");
            if (PhotonNetwork.PlayerList.Length == players.Length) {
                started = true;
                if (PhotonNetwork.IsMasterClient) {
                    Debug.Log("Spawned banana");
                    banana = PhotonNetwork.Instantiate("Bananabomb", transform.position, transform.rotation);
                } else {
                    
                }
                Debug.Log("BananaStart");
                StartCoroutine(GiveBananaStart());
            }
        }
        if (timerstart)
        {
            bombTime += Time.deltaTime;
        }

        if (bombTime >= explodeTime)
        {
            Explode();
        }

    }
    [PunRPC]
    public void SyncBanana() {
        cooldown = true;
        StartCoroutine(GiveBanan());
    }
    [PunRPC]
    IEnumerator GiveBanan()
    {
        BananaTransfer();
        Debug.Log("hai");
        yield return new WaitForSeconds(2);
        photonView.RPC("CooldownEnd", RpcTarget.All);
    }
    [PunRPC]
    void BananaTransfer()
    {
        if (cooldown) {
            bananaholder = hit.transform.parent.GetChild(2).GetChild(1);
            Debug.Log("Hit is van:" + hit.transform.parent.GetComponent<PhotonView>().IsMine);
            banana.transform.GetComponent<PhotonView>().RequestOwnership();
            Debug.Log(bananaholder.name.ToString() + "XD gaste");
            Debug.Log("bananaTransfer");
            cooldown = true;
            timerstart = true;
            previouseHolder = hit;
            transform.parent = null;
            banana.transform.GetComponent<Rigidbody>().isKinematic = true;
            banana.transform.GetComponent<Rigidbody>().useGravity = false;
            banana.transform.GetComponent<BoxCollider>().isTrigger = true;
            banana.transform.parent = bananaholder;
            banana.transform.position = bananaholder.position;
            if (hit.transform.parent.GetComponent<PhotonView>().IsMine && !transferOnExplode) {
                XROrigin[] rigs = FindObjectsOfType<XROrigin>();
                foreach (XROrigin xrrig in rigs) {
                    if (xrrig.gameObject.tag == "Player") {
                        ExpandedMovementProvider.stunTime = 5;
                        xrrig.GetComponent<ExpandedMovementProvider>().Stun();
                    } else {
                        VR_Overide.stunTime = 5;
                        xrrig.GetComponent<VR_Overide>().Stun();
                    }
                }
            }
            transferOnExplode = false;
        }
    }
    [PunRPC]
    void CooldownEnd() 
    {
        cooldown = false;
    }
    public void Explode() {
        if (hit.GetComponentInParent<PhotonView>().IsMine) {
            Debug.Log("Exploded");
            FindObjectOfType<XROrigin>().transform.position = cage.position;
        }
        if (PhotonNetwork.IsMasterClient) {
            Debug.Log("adiing points to " + Math.Round(Convert.ToDouble(hit.GetComponentInParent<PhotonView>().ViewID / 1000), 0));
            PointSystem.AddPoints(Convert.ToInt32(Math.Round(Convert.ToDouble(hit.GetComponentInParent<PhotonView>().ViewID / 1000))), pointsOnExplode);
            Debug.Log(PointSystem.playerPoints.ToString());
        }
        transferOnExplode = true;
        hit.tag = "IsDead";
        players = GameObject.FindGameObjectsWithTag("IsPlayer");
        PointsEnWin();
        hit = players[UnityEngine.Random.Range(0, PhotonNetwork.PlayerList.Length)].GetComponent<Collider>();
        SyncBanana();
        bombTime = 0;
    }
    public void PointsEnWin() {
        if(players.Length <= 1) {
            //point system gebeure
            if (PhotonNetwork.IsMasterClient && !ended) {
                Debug.Log("sceneswitch :" + SwitchScenesTest.switchs);
                SwitchScenesTest.switchs = true;
                PhotonNetwork.LoadLevel("Game");
                ended = true;
            }
        }
    }
}
