using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup3 : Popup
{
    public static Popup instance;
    void Awake() {
        instance = this;
        hide();
    }
    
    void Update()
    {
        if(popup2.instance.done && firstCheck) {
            StartCoroutine(stopHeadAfterSeconds(1f));
            popup2.instance.hide();

        }

        if(secondCheck && Input.GetAxis("Fire1") != 0) {
            Head.instance.isMoving = true;

            secondCheck = false;
        }

        if(!firstCheck && !secondCheck && FoodManager.instance.getFood().getNearbyDirt() > 0) {
            hide();

            done = true;
        }
        
    }


}