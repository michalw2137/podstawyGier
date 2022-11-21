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
        //type = new Type();
        int rnd = Random.Range(0, 3);
        Debug.Log($"random int = {rnd}");

        switch(rnd) {
            case 1:
                type = TypeDry.instance;
                break;
            case 0:
                type = TypeNormal.instance;
                break;
            case 2:
                type = TypeWet.instance;
                break;
        }
        Debug.Log($"Type = {type}");
        sr.color = type.defaultColor;
        this.tag = "deafaultDirt";
    }

    void Update()
    {
        //Debug.Log($"fire: {Input.GetAxis("Fire1")}");
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
            if(status == Status.eaten
            && Input.GetAxis("Fire1") == 1
            && Ass.instance.canChangeDirtCount(-1)
            ) {
                status = Status.fertilizer;
                updateColor();
                
                FoodManager.instance.addParticle(this);       
                
            } 
        } 

        if (other.tag == "head") {
            if (status == Status.eatable) {
                //Debug.Log($"touched HEAD");
                status = Status.eaten;
                updateColor();
                
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

    private void updateColor() 
    {
        sr.color = type.GetColor(status);
    }

    public void resetColor()
    {
        sr.color =  type.defaultColor;
    }


}
