using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public void ButtonQuit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Quiting");
        Application.Quit();
    }
}
