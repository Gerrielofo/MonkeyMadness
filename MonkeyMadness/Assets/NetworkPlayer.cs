using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class NetworkPlayer : MonoBehaviour {
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public Transform center;
    private PhotonView photonView;

    public Animator leftHandAnimator;
    public Animator rightHandAnimator;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;
    private Transform centerRig;

    // Start is called before the first frame update
    void Start() {
        photonView = GetComponent<PhotonView>();
        XROrigin rig = FindObjectOfType<XROrigin>();
        headRig = Camera.main.transform;
        leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");
        centerRig = rig.transform.Find("Camera Offset/Center");
        //leftHandAnimator = rig.transform.Find("Camera Offset/LeftHand Controller/Custom Left Hand Model").GetComponent<Animator>();
        //rightHandAnimator = rig.transform.Find("Camera Offset/RightHand Controller/Custom right Hand Model").GetComponent<Animator>();
        if (photonView.IsMine) {
            foreach (var item in GetComponentsInChildren<Renderer>()) {
                item.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (photonView.IsMine) {

            MapPosition(head, headRig);
            MapPosition(leftHand, leftHandRig);
            MapPosition(rightHand, rightHandRig);
            MapPosition(center, centerRig);

            if(leftHandAnimator != null && rightHandAnimator != null) {
                UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
                UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
            }
        }
    }

    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator) {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) {
            handAnimator.SetFloat("Trigger", triggerValue);
        } else {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue)) {
            handAnimator.SetFloat("Grip", gripValue);
        } else {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void MapPosition(Transform target, Transform rigTransform) {
        
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }

    public void SetRightHandAnimator(Animator hand) {
        rightHandAnimator = hand;
    }

    public void SetLeftHandAnimator(Animator hand) {
        leftHandAnimator = hand;
    }
}
