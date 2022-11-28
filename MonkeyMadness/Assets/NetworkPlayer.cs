using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkPlayer : MonoBehaviour {
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    public Transform headRig;
    public Transform leftHandRig;
    public Transform rightHandRig;

    // Start is called before the first frame update
    void Start() {
        photonView = GetComponent<PhotonView>();
        XRRig rig = FindObjectOfType<XRRig>();
    }

    // Update is called once per frame
    void Update() {
        if (photonView.IsMine) {
            rightHand.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            head.gameObject.SetActive(false);

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);

        }


    }

    void MapPosition(Transform target, Transform rigTransform) {
        
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}
