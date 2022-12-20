using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtParticle : MonoBehaviour
{
    //[SerializeField] public Color defaultColor = new Color(231, 200, 128, 128); 

    private SpriteRenderer sr;

    public Type type {get; set;}
    public Status status {get; set;}

    void Awake()
    {
        sr = this.GetComponent<SpriteRenderer>();
        this.type = TypeNormal.instance;
        this.tag = "deafaultDirt";

        setStatus(Status.eatable);
    }

    void Start() { }

    void Update() { }

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
        if(other.tag == "DirtDry") {
            setType(TypeDry.instance);
        }
         if(other.tag == "DirtWet") {
            setType(TypeWet.instance);
        }

        if (other.tag == "ass") {
            if(Input.GetAxis("Fire1") == 1) {
                Ass.instance.respawnParticle(this);
            } 
        } 
        if (other.tag == "head") {
            Ass.instance.eatParticle(this);
            
        } 
    }

    public void setStatus(Status status) {
        this.status = status;
        updateColor();
    }

    public void setType(Type type) 
    {
        this.type = type;
        updateColor();
    }

    private void updateColor() 
    {
        sr.color = type.GetColor(status);
        sr.sprite = type.GetSprite(status);
    }

    public void resetColor()
    {
        sr.color =  type.defaultColor;
    }


}
