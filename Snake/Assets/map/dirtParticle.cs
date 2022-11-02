using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirtParticle : MonoBehaviour
{
    [SerializeField] public Color defaultColor = new Color(231, 200, 128, 128); 
    [SerializeField] public Color deletedColor = new Color(0, 0, 0, 0); 
    private SpriteRenderer sr;

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "ass") {
            //Debug.Log("[DIRT] dirt touched ass \n");

            if(sr.color == deletedColor && Input.GetKey(KeyCode.Space)) {
                sr.color = defaultColor;
                Debug.Log("[DIRT] spawning dirt \n");

                eatingDirt.instance.changeDirtCount(-1);
            }   
        } 

        if (other.tag == "head") {
            if (sr.color == defaultColor) {
                sr.color = deletedColor;
                eatingDirt.instance.changeDirtCount(1);
               // Debug.Log("count ++\n");
            }
            

        } 
    }

    // Start is called before the first frame update
    void Awake()
    {
        sr = this.GetComponent<SpriteRenderer>();
        sr.color = defaultColor;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
