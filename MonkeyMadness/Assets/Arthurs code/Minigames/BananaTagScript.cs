using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaTagScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Transform bananholder = other.gameObject.transform.GetChild(0).GetChild(1);
            transform.position = bananholder.position;
            transform.parent = bananholder;
        }
    }
}
