using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSceneSwitch : MonoBehaviour
{
    public void ForceLoadScene(string sceneToLoad)
    {
        SwitchScenesTest.switchs = true;
        SwitchScenesTest.sceneToLoad = sceneToLoad;
        StartCoroutine(SwitchScenesTest.SceneSwitch());
    }
}
