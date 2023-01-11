using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashManager : MonoBehaviour
{
    public SquashManager instance;

    public GameObject seed;
    
    private Animator anim;

    void Awake() {
        instance = this;
        //animation["Squash"].wrapMode = WrapMode.Once;
        anim = seed.GetComponent<Animator>();
    }

    void Start() {
        
    }

    public void triggerSquash() 
    {
        anim.StopPlayback();
        anim.Play("Squash");
    }

    public void triggerShitting() 
    {
        anim.StopPlayback();
        anim.Play("shitting_squash");
    }

    public void triggerIncreaseSquash() 
    {
        if((anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0)))
        {
            anim.Play("Inc");
        }
        
    }
}
