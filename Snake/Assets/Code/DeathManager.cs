using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public static DeathManager instance;

    public GameObject head;
    
    public Animator anim;

    void Awake() {
        instance = this;
        anim = head.GetComponent<Animator>();
    }

    void Start() {

    }

    public IEnumerator triggerDeath() 
    {
        //Debug.Log("starting anim");

        anim.Play("Death");

        float animationLength = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animationLength);
        //Debug.Log("Done Playing");
    }

    
}
