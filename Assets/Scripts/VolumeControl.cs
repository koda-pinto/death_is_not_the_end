using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSlider.onValueChanged.AddListener(UpdateMusicVolume);
        sfxSlider.onValueChanged.AddListener(UpdateSFXVolume); 

        musicSlider.value = AudioManager.MUSICVOLUME; //set the slider to the current volume
        sfxSlider.value = AudioManager.SFXVOLUME; //set the slider to the current volume
    }

    public void UpdateMusicVolume(float value)
    {
        AudioManager.MUSICVOLUME = value;

        if (AudioManager.Instance != null && AudioManager.Instance.musicSource != null)
        {
            AudioManager.Instance.musicSource.volume = value;
        }
    }   
    public void UpdateSFXVolume(float value)
    {
        AudioManager.SFXVOLUME = value;

        if (AudioManager.Instance != null && AudioManager.Instance.sfxSource != null)
        {
            AudioManager.Instance.sfxSource.volume = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Hello World");
        // Debug.Log(AudioManager.MUSICVOLUME);
        // Debug.Log(AudioManager.SFXVOLUME);
    }
}
