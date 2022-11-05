using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtParticle : MonoBehaviour
{
    //[SerializeField] public Color defaultColor = new Color(231, 200, 128, 128); 
    [SerializeField] public Color defaultColor = new Color(116, 62, 31, 128); 

    [SerializeField] public Color deletedColor = new Color(0, 0, 0, 0); 

    private SpriteRenderer sr;

    void Awake()
    {
        sr = this.GetComponent<SpriteRenderer>();
        sr.color = defaultColor;
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other) 
    {   // DEBUG DONT DELETE
        // if (other.tag == "ass") {
        //     if(sr.color == deletedColor 
        //     ) {
        //         Ass.instance.changeDirtCount(-1);
        //         sr.color = Color.red;
        //     } 
        //     else {
        //         sr.color = Color.blue;
        //     }
        // } 

        if (other.tag == "ass") {
            if(sr.color == deletedColor 
            && Input.GetKey(KeyCode.Space)
            ) {
                sr.color = defaultColor;
                Ass.instance.changeDirtCount(-1);
            } 
        } 

        if (other.tag == "head") {
            if (sr.color == defaultColor) {
                sr.color = deletedColor;
                Ass.instance.changeDirtCount(1);
            } 
        } 
    }




}
