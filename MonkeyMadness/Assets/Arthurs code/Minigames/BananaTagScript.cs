using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using Unity.VisualScripting;
using Photon.Pun.UtilityScripts;

public class BananaTagScript : MonoBehaviour 
{
    private PhotonView photonView;
    private bool cooldown;
    public Collider previouseHolder;
    public GameObject[] players;
    public float bombTime;
    public int explodeTime;
    public bool timerstart;
    public PointSystem pointsustem;
    public int points;
    // Start is called before the first frame update
    void Start() {
        photonView = GetComponent<PhotonView>();
        
        players = GameObject.FindGameObjectsWithTag("IsPlayer");
        Collider other = players[Random.Range(0, PhotonNetwork.PlayerList.Length)].GetComponent<Collider>();
        GiveBanan(other);

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
        if (other.GetComponentInParent<PhotonView>().IsMine) {
            if (other.CompareTag("IsPlayer") && !cooldown && other != previouseHolder) {
                StartCoroutine(GiveBanan(other));
                
            }
        }
    }
    IEnumerator GiveBanan(Collider other) 
    {
        photonView.RequestOwnership();
        Transform bananaholder = other.transform.parent.GetChild(2).GetChild(1);
        photonView.RPC("BananaTransfer", RpcTarget.All, other, bananaholder);
        yield return new WaitForSeconds(5);
        photonView.RPC("CooldownEnd", RpcTarget.All);
    }
    [PunRPC]
    void BananaTransfer(Collider other, Transform bananaholder) 
    {
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
        //transform = cage
        GetComponentInParent<Transform>().GetComponentInParent<Transform>().tag = "IsDead";
        pointsustem.AddPoints(points, PlayerNumberingExtensions.GetPlayerNumber(PhotonNetwork.LocalPlayer));
        points++;
        players = GameObject.FindGameObjectsWithTag("IsPlayer");
        Collider other = players[Random.Range(0, PhotonNetwork.PlayerList.Length)].GetComponent<Collider>();
        GiveBanan(other);
    }
}
