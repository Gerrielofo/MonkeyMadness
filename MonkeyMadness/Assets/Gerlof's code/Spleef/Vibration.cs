using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Vibration : MonoBehaviour
{
    private XRController xr;

    public float duration;
    public float Amplitude;
    public XRBaseInteractable MyObject;
    public XRBaseInteractor LeftController, RightController;
    void Start()
    {
        xr = (XRController)GameObject.FindObjectOfType(typeof(XRController));

        if (MyObject.isSelected && MyObject.IsSelectableBy(LeftController))
        {
            xr.SendHapticImpulse(Amplitude, duration);
            print("Virbrate Left Controller");
        }
        else if (MyObject.isSelected && MyObject.IsSelectableBy(RightController))
        {
            xr.SendHapticImpulse(Amplitude, duration);
            print("Virbrate Right Controller");
        }
    }  
}