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
        if (other.CompareTag("IsPlayer"))
        {
            Transform bananholder = other.gameObject.transform.GetChild(2).GetChild(1);
            print("multiplayerRig");
            transform.position = bananholder.position;
            transform.parent = null;
            transform.position = bananholder.position;
            transform.parent = bananholder;
            transform.GetComponent<Rigidbody>().useGravity = false;
            transform.GetComponent<BoxCollider>().isTrigger = true;
            transform.position = bananholder.position;
            photonView.RequestOwnership();
            
        }
    }
}
