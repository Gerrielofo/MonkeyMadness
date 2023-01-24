using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartbordSection : MonoBehaviour
{
    public int MinigameID;
    public string MinigameName;
    public int radius;
    public GameObject MinigameLoader;
    private void Update() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders) {
            if (hitCollider.CompareTag("Dart")) {
                ReadyRoomSystem.sceneToLoad = MinigameName;
            }
        }
    }

}
