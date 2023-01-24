using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartbordSection : MonoBehaviour
{
    public int MinigameID;
    public string MinigameName;
    public int radius;
    public GameObject MinigameLoader;
    public void Update() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

        foreach (var hitCollider in hitColliders) {
            if (hitCollider.CompareTag("Dart")) {
                Debug.Log("Dart Hit");
                ReadyRoomSystem.sceneToLoad = MinigameName;
            }
        }
    }

}
