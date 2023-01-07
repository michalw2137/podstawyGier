using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackController : MonoBehaviour
{
    public static SoundtrackController instance;

    public AudioSource audioSource;

    void Start()
    {
        audioSource.Play();
    }

    void Awake() {
        if(instance == null) {
            instance = this;
        }

        GameObject [] musicObj =  GameObject.FindGameObjectsWithTag("soundtrack");
        if(musicObj.Length >2 ) 
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void setPlaying(bool playing) {
        if(playing) {
            audioSource.Play();
        } else {
            audioSource.Stop();
        }
    }
}
