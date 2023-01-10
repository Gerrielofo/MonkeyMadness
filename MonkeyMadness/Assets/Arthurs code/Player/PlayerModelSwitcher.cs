using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelSwitcher : MonoBehaviour
{
    public GameObject[] playerModels;
    int currentModel = 0;
    public void SwitchModel() {
        if(currentModel < playerModels.Length) {
            playerModels[currentModel].SetActive(false);
            currentModel++;
            playerModels[currentModel].SetActive(true);
        } else {
            currentModel = 0;
        }
    }
}
