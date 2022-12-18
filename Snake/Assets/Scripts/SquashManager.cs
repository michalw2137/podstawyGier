using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashManager : MonoBehaviour
{
    public SquashManager instance;

    public GameObject seed;
    
    

    void Awake() {
        instance = this;
        //animation["Squash"].wrapMode = WrapMode.Once;
        
    }

    void Start() {
        
    }

    public void triggerSquash() 
    {
        seed.GetComponent<Animator>().Play("Squash");
    }
}
