using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Slider volume;
    public float masterVolume;
    
    public void ChangeMasterVolume()
    {
        masterVolume = volume.value;
        AkSoundEngine.SetRTPCValue("masterVolume", masterVolume);
    }
}
