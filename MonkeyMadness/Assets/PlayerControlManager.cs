using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;


public class PlayerControlManager : MonoBehaviourPunCallbacks {
    public ActionBasedController leftController;
    public ActionBasedController rightController;
    public Component[] componentsToDissable;
    public Camera cam;
    public PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine) {
            MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour c in comps) {
                if (c != this) {
                    c.enabled = false;
                }
            }
            cam.enabled = false;
            leftController.enabled = false;
            rightController.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
