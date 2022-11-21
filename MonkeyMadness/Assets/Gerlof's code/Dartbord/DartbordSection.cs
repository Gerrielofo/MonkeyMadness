using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartbordSection : MonoBehaviour
{
    public int minigameID;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Dart")
        {
            switch (minigameID)
            {
                case 1:
                    print("Playing minigame 1");
                    break;
                case 2:
                    print("Playing minigame 2");
                    break;
                case 3:
                    print("Playing minigame 3");
                    break;
                case 4:
                    print("Playing minigame 4");
                    break;
                case 5:
                    print("Playing minigame 5");
                    break;
                case 6:
                    print("Playing minigame 6");
                    break;
            }
        }
    }
}
