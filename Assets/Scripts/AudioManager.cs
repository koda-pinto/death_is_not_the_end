using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public static AudioManager Instance; //so that we can access this class from other classes
    public static float MUSICVOLUME = 0.5f;
    public static float SFXVOLUME = 0.5f;


    public Sound[] musicSounds, sfxSounds; //class to hold music and sfx!
    public AudioSource musicSource, sfxSource; //idk what this does yet but it was in the tutorial

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //this makes sure that the audio manager persists between scenes
        }
        else
        {
            Destroy(gameObject); //if there is already an instance of this class, destroy this one
        }
    }

    // private void Start()
    // {
    //     PlayMusic("Placeholder");
    // }

    // public void Click()
    // {
    //     PlaySFX("Click");
    // }

    public void PlayMusic(string name)
    {    
        Sound s = Array.Find(musicSounds, x => x.name == name); //plays the music with the name passed in

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.volume = MUSICVOLUME ; 
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
                Sound s = Array.Find(sfxSounds, x => x.name == name); //plays the sfx with the name passed in

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            sfxSource.volume = SFXVOLUME;
            sfxSource.PlayOneShot(s.clip);
        }

    }

}
