using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMinigame : MonoBehaviour
{
    private GameObject[] players;
    public static int playercount;
    private void Start()
    {
        playercount = players.Length;
        if(playercount == players.Length)
        {
            for (int i = 0; i < playercount; i++)
            {
                players[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }   
            StartCoroutine(GameCountdown());
        }
    }
    IEnumerator GameCountdown()
    {
        yield return new WaitForSeconds(5);
        for (int i = 0; i < playercount; i++)
        {
            players[i].GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeAll;
        }
    }
}
