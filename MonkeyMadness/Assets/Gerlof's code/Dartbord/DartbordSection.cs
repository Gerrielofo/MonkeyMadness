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
                    MinigameLoader.GetComponent<SwitchScenesTest>().SwitchScene(MinigameID -1);
                    break;
                case 2:
                    //print("Playing " + MinigameName);
                    MinigameLoader.GetComponent<SwitchScenesTest>().SwitchScene(MinigameID - 1);
                    break;
                case 3:
                    //print("Playing " + MinigameName);
                    MinigameLoader.GetComponent<SwitchScenesTest>().SwitchScene(MinigameID - 1);
                    break;
                case 4:
                    //print("Playing " + MinigameName);
                    MinigameLoader.GetComponent<SwitchScenesTest>().SwitchScene(MinigameID - 1);
                    break;
                case 5:
                    //print("Playing " + MinigameName);
                    MinigameLoader.GetComponent<SwitchScenesTest>().SwitchScene(MinigameID);
                    break;
                case 6:
                    //print("Playing " + MinigameName);
                    MinigameLoader.GetComponent<SwitchScenesTest>().SwitchScene(MinigameID);
                    break;
            }
        }
    }
}
