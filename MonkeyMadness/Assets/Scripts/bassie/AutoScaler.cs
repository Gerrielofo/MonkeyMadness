using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaler : MonoBehaviour
{
    public float MonkeyHeight = 1f;

    public GameObject cameraHeight;
    public GameObject player;


    private void Start()
    {
        StartCoroutine(WaitAndResize());
    }

    void Resize()
    {
        float headHeight = cameraHeight.transform.localPosition.y;
        float scale = MonkeyHeight / headHeight;
        transform.localScale = Vector3.one * scale;
    }


    public IEnumerator WaitAndResize()
    {
        yield return new WaitForSeconds(5);
        Resize();
    }
}
