using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public Sprite[] audioSprites;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }

        else
        {
            load();
        }


    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        save();
    }

    private void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}