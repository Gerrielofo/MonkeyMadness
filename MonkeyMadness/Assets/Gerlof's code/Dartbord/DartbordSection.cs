using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartbordSection : MonoBehaviour
{
    [SerializeField] private int MinigameID;
    [SerializeField] private string MinigameName;
    
    public GameObject MinigameLoader;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Dart")
        {
            switch (MinigameID)
            {
                case 1:
                    //print("Playing " + MinigameName);
                    MinigameLoader.GetComponent<SwitchScenesTest>().sceneToLoad = (MinigameID - 1);
                    MinigameLoader.GetComponent<SwitchScenesTest>().canChange = true;
                    break;
                case 2:
                    //print("Playing " + MinigameName);
                    MinigameLoader.GetComponent<SwitchScenesTest>().sceneToLoad = (MinigameID - 1);
                    MinigameLoader.GetComponent<SwitchScenesTest>().canChange = true;
                    break;
                case 3:
                    //print("Playing " + MinigameName);
                    MinigameLoader.GetComponent<SwitchScenesTest>().sceneToLoad = (MinigameID - 1);
                    MinigameLoader.GetComponent<SwitchScenesTest>().canChange = true;
                    break;
                case 4:
                    //print("Playing " + MinigameName);
                    MinigameLoader.GetComponent<SwitchScenesTest>().sceneToLoad = (MinigameID - 1);
                    MinigameLoader.GetComponent<SwitchScenesTest>().canChange = true;
                    break;
            }
        }
    }
}
