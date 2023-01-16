using Photon.Pun.UtilityScripts;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTSHIT : MonoBehaviour
{
    public bool bababasndfba;
    private void Update()
    {
        if (bababasndfba)
        {
            if (PlayerNumberingExtensions.GetPlayerNumber(PhotonNetwork.LocalPlayer) == 1)
            {
                print("ashdfui");
            }
        }
    }
}
