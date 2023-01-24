using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScaler : MonoBehaviour
{
    public float MonkeyHeight = 1f;

    public GameObject cameraHeight;
    public GameObject player;

    float distance;

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
        RaycastHit hit;
        if (Physics.Raycast(cameraHeight.transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            distance = hit.distance;
        }
        float headHeight = cameraHeight.transform.localPosition.y;
        float scale = distance / headHeight * MonkeyHeight;
        transform.localScale = Vector3.one * scale;
    }


    public IEnumerator WaitAndResize()
    {
        yield return new WaitForSeconds(2);
        Resize();
    }
}
