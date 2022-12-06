using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBoxManager : MonoBehaviour
{
    public GameObject box;
    public GameObject cloneBox;

    public Transform boxSpawnpoint;
    private void Start()
    {
        SpawnBox();
    }
    public void SpawnBox()
    {
        cloneBox = Instantiate(box, boxSpawnpoint);
        cloneBox.GetComponent<CrossBox>().manager = this;
    }
}