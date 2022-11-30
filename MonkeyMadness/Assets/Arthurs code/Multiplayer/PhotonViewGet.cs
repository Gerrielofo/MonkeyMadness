using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonViewGet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
