using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartbordSection : MonoBehaviour
{
    public int MinigameID;
    public string MinigameName;
    public int radius;
    public GameObject MinigameLoader;
    private bool hit;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Dart Hit");
        SwitchScenesTest.sceneToLoad = MinigameName;
    }

}
