using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour
{
    [SerializeField] AudioMixer masterMixer;
    public void SetMasterVol(float masterLvl)
    {
        masterMixer.SetFloat("masterVol", masterLvl);
    }

    public void SetSFXVol(float sfxLvl)
    {
        masterMixer.SetFloat("sfxVol", sfxLvl);
    }

    public void SetMusicVol(float musicVol)
    {
        masterMixer.SetFloat("musicVol", musicVol);
    }
}
