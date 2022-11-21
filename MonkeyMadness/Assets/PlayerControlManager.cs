using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;


public class PlayerControlManager : MonoBehaviourPunCallbacks {
    public ActionBasedController leftController;
    public ActionBasedController rightController;
    public PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine) {
            leftController.enabled = false;
            rightController.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
