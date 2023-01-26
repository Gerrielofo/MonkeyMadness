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

    public static bool isStunned;
    public static float stunTime;
    public static float stunDelay;
    private void Start() {
        xrOrigon.SetActive(false);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
    }

    void Update() {
        if (!isStunned) {
            rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0)));
            rigidbody.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed));
        }
    }

    public void ForceLoadScene() {
        SwitchScenesTest.sceneToLoad = sceneToLoad;
        StartCoroutine(SwitchScenesTest.SceneSwitch());
    }
    public void Stun() {
        stunDelay = 2f;
        isStunned = true;
        StartCoroutine(Stunned());
    }
    private IEnumerator Stunned() {
        yield return new WaitForSeconds(stunTime);
        isStunned = false;
    }
}