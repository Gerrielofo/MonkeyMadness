using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtenInVr : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public GameObject presser;
    public bool isPressed;

    public float buttonDistance;
    float buttonHome;
 
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        buttonHome = transform.localPosition.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, buttonDistance, 0);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        button.transform.localPosition = new Vector3(0, buttonHome, 0);
        onRelease.Invoke();
        isPressed = false;
    }
}
