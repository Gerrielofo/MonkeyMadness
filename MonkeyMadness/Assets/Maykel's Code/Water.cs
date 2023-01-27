using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;
using System;

public class Water : MonoBehaviour
{
    public BananaTagScript bananatagscript;

    public TMP_Text waterTXT;

    public bool waterHit;

    public float waterTime;

    public GameObject other;

    public ExpandedMovementProvider momentvider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("IsPlayer"))
        {
            UnityEngine.Debug.Log("hasdhufqwhefuqwhe");
            this.other = other.transform.gameObject;
            waterTXT.enabled = true;
            waterHit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("IsPlayer"))
        {
            waterHit = false;
            waterTXT.enabled = false;
            UnityEngine.Debug.Log("hasdhufqwhefuqwhe");
            waterTime = 5;
            momentvider.waterTouch = false;
        }
    }
    private void Update()
    {
        if (waterHit) { 
            waterTime -= Time.deltaTime;
            waterTXT.text = Math.Round(waterTime, 0).ToString();
            momentvider.waterTouch = true;
        }

        if (waterTime < 0) {
            if (bananatagscript.hit == other) { 
                bananatagscript.Explode();
                waterHit = false;
                waterTime = 5;
            } else {
                other.tag = "IsDead";
                bananatagscript.players = GameObject.FindGameObjectsWithTag("IsPlayer");
                bananatagscript.PointsEnWin();
                waterHit = false;
                waterTime = 5;
            }
        }
    }
}
