using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider volume;
    public float masterVolume;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
            Load();
        }
        else Load();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volume.value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volume", volume.value);
    }

    private void Load()
    {
        volume.value = PlayerPrefs.GetFloat("volume");
    }

    public void ChangeMasterVolume()
    {
        masterVolume = volume.value;
        AkSoundEngine.SetRTPCValue("masterVolume", masterVolume);
    }
}
