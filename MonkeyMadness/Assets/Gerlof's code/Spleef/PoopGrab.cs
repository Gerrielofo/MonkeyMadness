using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PoopGrab : MonoBehaviour
{
    [SerializeField] private GameObject poopPrefap;

    [SerializeField] private XRController xr;

    [SerializeField] private float duration;
    [SerializeField] private float Amplitude;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands") && other.GetComponent<XRDirectExtraInteractor>().heldItem == null)
        {
            //xr = other.transform.GetComponent<XRController>();
            //xr = (XRController)GameObject.FindObjectOfType(typeof(XRController));
            //xr.SendHapticImpulse(Amplitude, duration);
            Instantiate(poopPrefap, transform.position, transform.rotation);
        }
    }
}