using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixLevels : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider masterSlider;
    public Slider sfxSlider;
    public Slider musicSlider;
    
    public void SetMasterVol(float masterLvl)
    {
        Debug.Log(masterLvl);
        masterMixer.SetFloat("masterVol", Mathf.Log10(masterSlider.value <= 0 ? 0.001f : masterSlider.value) * 40f);
    }

    public void SetSFXVol(float sfxLvl)
    {
        masterMixer.SetFloat("sfxVol", Mathf.Log10(sfxSlider.value <= 0 ? 0.001f : sfxSlider.value) * 40f);
    }

    public void SetMusicVol(float musicVol)
    {
        masterMixer.SetFloat("musicVol", Mathf.Log10(musicSlider.value <= 0 ? 0.001f : musicSlider.value) * 40f);
    }
}
