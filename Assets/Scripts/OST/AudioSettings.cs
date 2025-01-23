using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer Mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX");

        SetMusicVolume();
        SetSFXVolume();
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        Mixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Music", volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        Mixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFX", volume);
        PlayerPrefs.Save();
    }
}
