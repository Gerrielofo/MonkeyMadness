using System.Collections;
using System.Collections.Generic;
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
    private bool cooldown;
    public Collider previouseHolder;
    public Collider hit;
    public GameObject[] players;
    public float bombTime;
    public int explodeTime = 50;
    public bool timerstart;
    private bool started;
    public Transform cage;
    //public PointSystem pointsustem;
    public int points;
    public Transform bananaholder;
    // Start is called before the first frame update
    void Start() {
        photonView = GetComponent<PhotonView>();
        

    }
    IEnumerator GiveBananaStart() {
        yield return new WaitForSeconds(5);
        Debug.Log("array length is" + players.Length);
        hit = players[Random.Range(0, players.Length)].GetComponent<Collider>();
        SyncBanana();
        yield return null;
    }
    private void Update()
    {
        if (!started) {
            photonView = GetComponent<PhotonView>();
            players = GameObject.FindGameObjectsWithTag("IsPlayer");
            if (PhotonNetwork.PlayerList.Length == players.Length) {
                started = true;
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
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("IsPlayer") && !cooldown && other != previouseHolder) {
            hit = other;
            photonView.RPC("SyncBanana", RpcTarget.AllBuffered);
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
        if (hit.GetComponentInParent<PhotonView>()) {
            photonView.RequestOwnership();
        }
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
            Debug.Log(bananaholder.name.ToString() + "XD gaste");
            Debug.Log("bananaTransfer");
            cooldown = true;
            timerstart = true;
            previouseHolder = hit;
            transform.parent = null;
            transform.GetComponent<Rigidbody>().isKinematic = true;
            transform.GetComponent<Rigidbody>().useGravity = false;
            transform.GetComponent<BoxCollider>().isTrigger = true;
            transform.parent = bananaholder;
            transform.position = bananaholder.position;
        }
    }
    [PunRPC]
    void CooldownEnd() 
    {
        cooldown = false;
    }
    public void Explode()
    {
        if (hit.GetComponentInParent<PhotonView>().IsMine) {
            FindObjectOfType<XROrigin>().transform.position = cage.position;
        }
        players = GameObject.FindGameObjectsWithTag("IsPlayer");
        hit = players[Random.Range(0, PhotonNetwork.PlayerList.Length)].GetComponent<Collider>();
        SyncBanana();
        bombTime = 0;
    }
}
