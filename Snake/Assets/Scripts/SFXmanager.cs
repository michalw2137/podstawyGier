using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXmanager : MonoBehaviour
{
    public SFXmanager instance;

    public AudioSource source;
    
    [SerializeField]
    public List<AudioClip> sfx = new List<AudioClip >();

    void Awake() {
        instance = this;
    }

    void Start() {
        setSource();
    }

    public void playSoundWithoutRepeat(int n) 
    {
        Debug.Log($"playing {n}");
        if(!source.isPlaying)
        {
            source.PlayOneShot(sfx[n]);
        }

    }

    public void playSound(int n) 
    {
        //Debug.Log($"playing {n}");
        source.PlayOneShot(sfx[n]);


    }

    private void setSource()
    {
        source.Stop();
    }
}
