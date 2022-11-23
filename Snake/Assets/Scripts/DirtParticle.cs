using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtParticle : MonoBehaviour
{
    //[SerializeField] public Color defaultColor = new Color(231, 200, 128, 128); 
    private SpriteRenderer sr;

    Type type;
    Status status;

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
        checkType(other);

        if (other.tag == "ass") {
            if(status == Status.eaten
            && Input.GetAxis("Fire1") == 1
            && Ass.instance.canChangeDirtCount(-1)
            ) {
                setStatus(Status.fertilizer);
                
                FoodManager.instance.addParticle(this);       
                
            } 
        } 

        if (other.tag == "head") {
            if (status == Status.eatable) {
                setStatus(Status.eaten);
                
                if(Input.GetAxis("Fire1") == 0) {
                    Ass.instance.canChangeDirtCount(1);
                    ParticleManager.instance.particling(false);

                } else {
                    ParticleManager.instance.particling(true);
                }

            } else {
                ParticleManager.instance.particling(true);
            }      
        } 
    }

    private void checkType(Collider2D other) {
        if(other.tag == "DirtDry") {
            setType(TypeDry.instance);
        }
         if(other.tag == "DirtWet") {
            setType(TypeWet.instance);
        }
    }

    private void setStatus(Status status) {
        this.status = status;
        updateColor();
    }

    private void setType(Type type) 
    {
        this.type = type;
        updateColor();
    }

    private void updateColor() 
    {
        sr.color = type.GetColor(status);
    }

    public void resetColor()
    {
        sr.color =  type.defaultColor;
    }


}
