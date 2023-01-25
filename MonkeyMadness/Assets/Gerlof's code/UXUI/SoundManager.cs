using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] GameObject volume14;
    [SerializeField] GameObject volume24;
    [SerializeField] GameObject volume34;
    [SerializeField] GameObject volume44;

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

    private void Update()
    {
        if (volumeSlider.value > -30f)
        {
            volume44.SetActive(true);
            volume34.SetActive(false);
            volume24.SetActive(false);
            volume14.SetActive(false);
        }
        else if (volumeSlider.value <= -30 && volumeSlider.value > -50f)
        {
            volume44.SetActive(false);
            volume34.SetActive(true);
            volume24.SetActive(false);
            volume14.SetActive(false);
        }
        else if (volumeSlider.value <= -50f && volumeSlider.value > -70f)
        {
            volume44.SetActive(false);
            volume34.SetActive(false);
            volume24.SetActive(true);
            volume14.SetActive(false);
        }
        else
        {
            volume44.SetActive(false);
            volume34.SetActive(false);
            volume24.SetActive(false);
            volume14.SetActive(true);
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