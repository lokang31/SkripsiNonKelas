using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAudio : MonoBehaviour
{
    string sound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       
        if (PlayerPrefs.GetString("Sound") == "On")
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
}
