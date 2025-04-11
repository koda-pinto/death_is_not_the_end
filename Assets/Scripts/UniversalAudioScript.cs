using UnityEngine;

public class UniversalAudioScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (audioName != "")
        {
            PlayMusic(audioName);
        }
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // public enum AudioType { Music, SFX }

    public string audioName;

    // public AudioType type = AudioType.Music; //default to music

    public void PlayMusic(string audioName)
    {
        if (AudioManager.Instance == null)
        {
            Debug.LogWarning("AudioManager is not in the scene!!");
            return;
        }
        else
        {
            AudioManager.Instance.PlayMusic(audioName);
        }
        // else
        // {
        //     AudioManager.Instance.PlaySFX(audioName);
        // }
    }

    public void PlaySFX(string audioName)
    {
        if (AudioManager.Instance == null)
        {
            Debug.LogWarning("AudioManager is not in the scene!!");
            return;
        }
        else
        {
            AudioManager.Instance.PlaySFX(audioName);
        }
    }
}
