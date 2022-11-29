using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaler : MonoBehaviour
{
    public float MonkeyHight = 1f;

    public GameObject cameraHight;
    public GameObject player;
    
    void Resize()
    {
        float headHight = cameraHight.transform.localPosition.y;
        float scale = MonkeyHight / headHight;
        transform.localScale = Vector3.one * scale;
    }

    
    void OnEnable()
    {
        Resize();
    }
}
