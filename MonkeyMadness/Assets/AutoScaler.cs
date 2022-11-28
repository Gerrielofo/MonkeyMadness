using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaler : MonoBehaviour
{
    public float MonkeyHight = 1f;

    public GameObject cameraHight;
    public GameObject player;
    // Start is called before the first frame update
    void Resize()
    {
        float headHight = cameraHight.transform.localPosition.y;
        float scale = MonkeyHight / headHight;
        transform.localScale = Vector3.one * scale;
    }

    // Update is called once per frame
    void OnEnable()
    {
        Resize();
    }
}
