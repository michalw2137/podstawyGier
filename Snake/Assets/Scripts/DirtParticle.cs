using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtParticle : MonoBehaviour
{
    //[SerializeField] public Color defaultColor = new Color(231, 200, 128, 128); 

    private SpriteRenderer sr;

    [SerializeField] public Types type {get; set;}
    [SerializeField] public Status status {get; set;}

    void Awake()
    {
        sr = this.GetComponent<SpriteRenderer>();
        this.tag = "deafaultDirt";

        setStatus(Status.eatable);
        this.type = Types.normal;
    }

    void Start() { 
        //this.type = Types.normal;

    }

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
            Debug.Log("dry dirt set");
            setType(Types.dry);
        }
         if(other.tag == "DirtWet") {
            setType(Types.wet);
        }

        if (other.tag == "ass") {
            if(Head.instance.isCutscene) {
                Ass.instance.respawnParticle(this);
            } else if(Input.GetAxis("Fire1") == 1) {
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

    public void setType(Types type) 
    {
        this.type = type;
        updateColor();
    }

    private void updateColor() 
    {
        Type typeObject = Type.getInstance(type);

        sr.color = typeObject.GetColor(status);
        sr.sprite = typeObject.GetSprite(status);        
    }



}
