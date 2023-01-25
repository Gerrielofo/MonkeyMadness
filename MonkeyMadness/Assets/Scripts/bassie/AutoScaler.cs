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

    public void ButtonResize()
    {
        StartCoroutine(WaitAndResize());
    }

    void Resize()
    {
        float headHeight = cameraHeight.transform.localPosition.y;
        float scale = MonkeyHeight / headHeight;
        player.transform.localScale = Vector3.one * scale;
    }


    public IEnumerator WaitAndResize()
    {
        player.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(2);
        Resize();
    }
}
