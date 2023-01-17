using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartbordSection : MonoBehaviour
{
    public int MinigameID;
    public string MinigameName;
    
    public GameObject MinigameLoader;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Dart")){
            ReadyRoomSystem.sceneToLoad = MinigameName;
        }
    }
}
