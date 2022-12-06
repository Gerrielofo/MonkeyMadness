using UnityEngine;

public class PoopGrab : MonoBehaviour
{
    [SerializeField] private GameObject poopPrefap;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands") && other.GetComponent<XRDirectExtraInteractor>().heldItem == null)
        {
            Instantiate(poopPrefap, transform.position, transform.rotation);
        }
    }
}