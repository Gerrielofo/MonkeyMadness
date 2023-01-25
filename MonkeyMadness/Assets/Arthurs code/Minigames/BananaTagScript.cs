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
    public bool cooldown;
    public Collider previouseHolder;
    public Collider hit;
    public GameObject[] players;
    public float bombTime;
    public int explodeTime = 50;
    public bool timerstart;
    private bool started;
    public bool spawned;
    public Transform cage;
    public GameObject banana;
    //public PointSystem pointsustem;
    public int points;
    public Transform bananaholder;
    // Start is called before the first frame update
    void Start() {
        photonView = GetComponent<PhotonView>();

    }
    IEnumerator GiveBananaStart() {
        yield return new WaitForSeconds(3);
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
                if (PhotonNetwork.IsMasterClient) {
                    Debug.Log("Spawned banana");
                    banana = PhotonNetwork.Instantiate("Bananabomb", transform.position, transform.rotation);
                } else {
                    banana = GameObject.FindGameObjectWithTag("Banana");
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
            if (hit.transform.parent.GetComponent<PhotonView>().IsMine) {
                banana.transform.GetComponent<PhotonView>().RequestOwnership();
            }
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
