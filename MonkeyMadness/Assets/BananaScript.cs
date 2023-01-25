using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaScript : MonoBehaviour
{
    public BananaTagScript bananaTagScript;
    public void Start() {
        bananaTagScript = GameObject.FindGameObjectWithTag("BananaTag").GetComponent<BananaTagScript>();
    }
    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("IsPlayer") && !bananaTagScript.cooldown && other != bananaTagScript.hit) {
            bananaTagScript.hit = other;
            bananaTagScript.SyncBanana();
        }
    }
}
