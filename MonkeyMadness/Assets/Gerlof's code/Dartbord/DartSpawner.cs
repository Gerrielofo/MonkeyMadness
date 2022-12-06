using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartSpawner : MonoBehaviour
{
    [SerializeField] private GameObject dart;

    private void Start()
    {
        SpawnDart();
    }
    public void SpawnDart()
    {
        Instantiate(dart, transform.position, transform.rotation);
    }
}
