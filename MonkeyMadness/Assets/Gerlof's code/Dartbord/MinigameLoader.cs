using UnityEngine.SceneManagement;
using UnityEngine;
using Photon.Pun;

public class MinigameLoader : MonoBehaviour
{
    public string MinigameName;
    private OnDoor Door;

    private void Start()
    {
        Door = GameObject.Find("Door").GetComponent<OnDoor>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (MinigameName != string.Empty && other.transform.tag == "Hands") 
        {
            print("Loading minigame:" + MinigameName);
            Door.openDoor.SetTrigger("OpenDoor");
            PhotonNetwork.LoadLevel(MinigameName);
        }
    }
}
