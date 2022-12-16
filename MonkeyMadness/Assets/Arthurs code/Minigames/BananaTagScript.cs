using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class BananaTagScript : MonoBehaviour
{
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start() {
        photonView = GetComponent<PhotonView>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("clientRig");

            //transform.parent = null;
            //other.GetComponent<BoxCollider>().enabled = false;
            //photonView.RequestOwnership();
            //Transform bananholder = other.gameObject.transform.GetChild(0).GetChild(2).GetChild(1);
            //transform.GetComponent<Rigidbody>().useGravity = false;
            //transform.GetComponent<BoxCollider>().isTrigger = true;
            //transform.position = bananholder.position;
            //transform.parent = bananholder;

        }
        if (other.CompareTag("IsPlayer"))
        {
            print("multiplayerRig");
            transform.position = other.transform.position;
            transform.parent = null;
        }
    }
}
