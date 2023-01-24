using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;
using Photon.Pun.UtilityScripts;

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
    //public PointSystem pointsustem;
    public int points;
    public Transform bananaholder;
    // Start is called before the first frame update
    void Start() {
        photonView = GetComponent<PhotonView>();
        

        StartCoroutine(GiveBananaStart());
    }
    IEnumerator GiveBananaStart() {
        yield return new WaitForSeconds(2);
        players = GameObject.FindGameObjectsWithTag("IsPlayer");
        Debug.Log("array length is" + players.Length);
        Collider other;
        other = players[Random.Range(0, players.Length)].GetComponent<Collider>();
        StartCoroutine(GiveBanan());
        yield return null;
    }
    private void Update()
    {
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
        StartCoroutine(GiveBanan());
    }
    [PunRPC]
    IEnumerator GiveBanan()
    {
        if (hit.GetComponentInParent<PhotonView>()) {
            photonView.RequestOwnership();
        }
        BananaTransfer(hit);
        Debug.Log("hai");
        yield return new WaitForSeconds(5);
        photonView.RPC("CooldownEnd", RpcTarget.All);
    }
    [PunRPC]
    void BananaTransfer(Collider other)
    {
        bananaholder = hit.transform.parent.GetChild(2).GetChild(1);
        Debug.Log(bananaholder.name.ToString() + "XD gaste");
        Debug.Log("bananaTransfer");
        cooldown = true;
        timerstart = true;
        previouseHolder = other;
        transform.parent = null;
        transform.GetComponent<Rigidbody>().isKinematic = true;
        transform.GetComponent<Rigidbody>().useGravity = false;
        transform.GetComponent<BoxCollider>().isTrigger = true;
        transform.parent = bananaholder;
        transform.position = bananaholder.position;
    }
    [PunRPC]
    void CooldownEnd() 
    {
        cooldown = false;
    }
    public void Explode()
    {
        /*
        if (photonView.IsMine)
        {
            GetComponentInParent<Transform>().GetComponentInParent<Transform>().tag = "IsDead";
        }
        players = GameObject.FindGameObjectsWithTag("IsPlayer");
        other = players[Random.Range(0, PhotonNetwork.PlayerList.Length)].GetComponent<Collider>();
        GiveBanan(other);
        bombTime = 0;
        */
    }
}
