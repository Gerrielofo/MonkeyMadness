using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Input;

public class PoopGrab : MonoBehaviour
{
    [SerializeField] private GameObject poopPrefap;

    [SerializeField] InputActionReference leftHapticAction;
    [SerializeField] InputActionReference rightHapticAction;

    [SerializeField] private float duration;
    [SerializeField] private float Amplitude;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            OpenXRInput.SendHapticImpulse(leftHapticAction, Amplitude, duration, UnityEngine.InputSystem.XR.XRController.leftHand);
        }
        else if (other.CompareTag("RightHand"))
        {
            OpenXRInput.SendHapticImpulse(rightHapticAction, Amplitude, duration, UnityEngine.InputSystem.XR.XRController.rightHand);
        }
        if (other.CompareTag("LeftHand") && other.GetComponent<XRDirectExtraInteractor>().heldItem == null ||  other.CompareTag("RightHand") && other.GetComponent<XRDirectExtraInteractor>().heldItem == null)
        {
            Instantiate(poopPrefap, transform.position, transform.rotation);
        }
    }
}