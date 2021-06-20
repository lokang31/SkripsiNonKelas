using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    string sound;
    AudioSource audioSource;
    public GameObject speakerOn, speakerOff;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.GetString("Sound") == "")
        {
            PlayerPrefs.SetString("Sound", "On");
        }
        else
        {
            if(PlayerPrefs.GetString("Sound") == "On")
            {
                audioSource.mute = false;
                speakerOn.SetActive(false);
                speakerOff.SetActive(true);
            }
            else
            {
                audioSource.mute = true;
                speakerOn.SetActive(true);
                speakerOff.SetActive(false);
            }
        }
        sound = PlayerPrefs.GetString("Sound");
        if(sound == "On")
        {
            audioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundOn()
    {
        PlayerPrefs.SetString("Sound", "On");
        audioSource.mute = false;
        speakerOn.SetActive(false);
        speakerOff.SetActive(true);
    }
    public void SoundOff()
    {
        PlayerPrefs.SetString("Sound", "Off");
        audioSource.mute = true;
        speakerOn.SetActive(true);
        speakerOff.SetActive(false);
    }
}
