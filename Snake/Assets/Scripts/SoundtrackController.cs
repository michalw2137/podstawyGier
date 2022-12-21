using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackController : MonoBehaviour
{
    
     public AudioSource audioSource;

     void Start()
     {
          audioSource.Play();
     }

    void Awake() {
        GameObject [] musicObj =  GameObject.FindGameObjectsWithTag("soundtrack");
        if(musicObj.Length >2 ) 
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
