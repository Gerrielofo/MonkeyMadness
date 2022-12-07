using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class XRVelocityInteractable : XRGrabInteractable
{
    private PhotonView photonView;
    [SerializeField] private Vector3 velocity;
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        photonView.RequestOwnership();
        base.OnSelectEntered(interactor);
    }
    void Update()
    {
        velocity = this.gameObject.GetComponent<Rigidbody>().velocity;
    }
}
