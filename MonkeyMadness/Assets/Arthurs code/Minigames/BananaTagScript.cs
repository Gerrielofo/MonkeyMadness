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
    public int explodeTime = 50;
    public bool timerstart;
    //public PointSystem pointsustem;
    public int points;
    public Collider other;
    public Transform bananaholder;
    // Start is called before the first frame update
    void Start() {
        photonView = GetComponent<PhotonView>();

        players = GameObject.FindGameObjectsWithTag("IsPlayer");
        other = players[Random.Range(0, PhotonNetwork.PlayerList.Length - 1)].GetComponent<Collider>();
        StartCoroutine(GiveBanan(other));
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
        bananaholder = other.transform.parent.GetChild(2).GetChild(1);
        Debug.Log(bananaholder.name.ToString() + "XD gaste");
        photonView.RPC("BananaTransfer", RpcTarget.All);
        Debug.Log("hai");
        yield return new WaitForSeconds(5);
        photonView.RPC("CooldownEnd", RpcTarget.All);
    }
    [PunRPC]
    void BananaTransfer()
    {
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
        if (photonView.IsMine)
        {
            GetComponentInParent<Transform>().GetComponentInParent<Transform>().tag = "IsDead";
            //pointsustem.AddPoints(points, PlayerNumberingExtensions.GetPlayerNumber(PhotonNetwork.LocalPlayer));
        }
        players = GameObject.FindGameObjectsWithTag("IsPlayer");
        other = players[Random.Range(0, PhotonNetwork.PlayerList.Length)].GetComponent<Collider>();
        GiveBanan(other);
        bombTime = 0;
    }
}
