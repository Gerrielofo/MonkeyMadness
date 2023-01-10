using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Input;

public class PoopGrab : MonoBehaviour
{
    [SerializeField] private GameObject poopPrefap;
    private GameObject poopItem;

    [SerializeField] InputActionReference leftHapticAction;
    [SerializeField] InputActionReference rightHapticAction;

    [SerializeField] private float duration;
    [SerializeField] private float Amplitude;
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            OpenXRInput.SendHapticImpulse(leftHapticAction, Amplitude, duration, UnityEngine.InputSystem.XR.XRController.leftHand);
            print("Virbrate Left Controller");
        }
        else if (other.CompareTag("RightHand"))
        {
            OpenXRInput.SendHapticImpulse(rightHapticAction, Amplitude, duration, UnityEngine.InputSystem.XR.XRController.rightHand);
            print("Virbrate Right Controller");
        }
        if (other.CompareTag("LeftHand") && other.GetComponent<XRDirectExtraInteractor>().heldItem == null ||  other.CompareTag("RightHand") && other.GetComponent<XRDirectExtraInteractor>().heldItem == null)
        {
            poopItem = (GameObject)Instantiate(poopPrefap, transform.position, transform.rotation);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<XRDirectExtraInteractor>().heldItem == null)
        {
            Destroy(poopItem); 
        }
        if (other.CompareTag("LeftHand"))
        {
            OpenXRInput.SendHapticImpulse(leftHapticAction, Amplitude, duration, UnityEngine.InputSystem.XR.XRController.leftHand);
            print("Virbrate Left Controller");
        }
        else if (other.CompareTag("RightHand"))
        {
            OpenXRInput.SendHapticImpulse(rightHapticAction, Amplitude, duration, UnityEngine.InputSystem.XR.XRController.rightHand);
            print("Virbrate Right Controller");
        }
    }
}