using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class XRGrabNetworkInteractable : XRGrabInteractable
{
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        photonView.RequestOwnership();
        this.gameObject.GetComponent<Collider>().isTrigger = true;
        base.OnSelectEntered(interactor);
    }
    protected override void Detach()
    {
        this.gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        this.gameObject.GetComponent<Collider>().isTrigger = false;
        base.Detach();

    }
}
