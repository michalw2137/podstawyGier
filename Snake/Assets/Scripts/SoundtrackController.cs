using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackController : MonoBehaviour
{
    void Awake() {
        GameObject [] musicObj =  GameObject.FindGameObjectsWithTag("soundtrack");
        if(musicObj.Length >1 ) 
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
