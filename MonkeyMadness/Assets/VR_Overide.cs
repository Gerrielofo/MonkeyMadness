using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Overide : MonoBehaviour {
    public CharacterController controller;
    public Rigidbody rigidbody;
    public GameObject xrOrigon;
    public Canvas canvas;
    public float mouseSensitivity;
    public float moveSpeed;
    public string sceneToLoad;
    public static bool vr_Overide = true;
    private void Start() {
        xrOrigon.SetActive(false);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
    }

    void Update() {
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0)));
        rigidbody.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed));
    }

    public void ForceLoadScene() {
        SwitchScenesTest.sceneToLoad = sceneToLoad;
        StartCoroutine(SwitchScenesTest.SceneSwitch());
    }
}