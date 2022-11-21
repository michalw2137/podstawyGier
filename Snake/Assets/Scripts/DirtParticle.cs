using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtParticle : MonoBehaviour
{
    //[SerializeField] public Color defaultColor = new Color(231, 200, 128, 128); 
    [SerializeField] public Color defaultColor = new Color(116, 62, 31, 128); 

    [SerializeField] public Color deletedColor = new Color(0, 0, 0, 0); 

    [SerializeField] public Color respawnedColor = new Color(0, 0, 0, 0); 

    private SpriteRenderer sr;

    void Awake()
    {
        sr = this.GetComponent<SpriteRenderer>();
        sr.color = defaultColor;
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
            if(sr.color == deletedColor 
            && Input.GetAxis("Fire1") == 1
            && Ass.instance.canChangeDirtCount(-1)
            ) {
                sr.color = respawnedColor;
                this.tag = "respawnedDirt";
                FoodManager.instance.addParticle(this);       
                
            } 
        } 

        if (other.tag == "head") {
            if (sr.color == defaultColor) {
                //Debug.Log($"touched HEAD");
                sr.color = deletedColor;
                this.tag = "eatenDirt";
                
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

    public void resetColor()
    {
        sr.color = defaultColor;
    }


}
