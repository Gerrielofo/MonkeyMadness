using UnityEngine.SceneManagement;
using UnityEngine;
using Photon.Pun;

public class MinigameLoader : MonoBehaviour
{
    public string MinigameName;
    private void OnTriggerEnter(Collider other)
    {
        if (MinigameName != string.Empty && other.transform.tag == "Hands") 
        {
            print("Loading minigame:" + MinigameName);
            PhotonNetwork.LoadLevel(MinigameName);
        }
    }
}
