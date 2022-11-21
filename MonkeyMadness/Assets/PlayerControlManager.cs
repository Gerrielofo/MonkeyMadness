using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;


public class PlayerControlManager : MonoBehaviourPunCallbacks {
    public ActionBasedController leftController, rightController;
    public XRDirectClimbInteractor leftControllerClimbing, rightControllerClimbing;
    public InputActionManager inputActionManager;
    public CharacterController charControl;
    public Component[] componentsToDissable;
    public Camera cam;
    public PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine) {
            MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour c in comps) {
                if (c != this && c != inputActionManager) {
                    c.enabled = false;
                }
            }
            inputActionManager.enabled = true;
            charControl.enabled = false;
            cam.enabled = false;
            leftController.enabled = false;
            rightController.enabled = false;
            leftControllerClimbing.enabled = false;
            rightControllerClimbing.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
