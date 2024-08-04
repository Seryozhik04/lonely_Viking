using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer am;

    public void AudioVolume(float sliderValue)
    {
        if (sliderValue == -40)
        {
            am.SetFloat("masterVolume", -80);
        }
        else
        {
            am.SetFloat("masterVolume", sliderValue);
        }
    }
}
