using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup4 : Popup
{
    public static Popup instance;
    void Awake() {
        instance = this;
        hide();
    }
    
    void Update()
    {
        if(popup3.instance.done && firstCheck) {
            StartCoroutine(stopHeadAfterSeconds(3f));
            popup3.instance.hideDelayed();

        }

        if(secondCheck && anyInput()) {
            Head.instance.isMoving = true;

            secondCheck = false;
        }

        if(!firstCheck && !secondCheck && FoodManager.instance.getFood().isRipe()) {
            hideDelayed();
            done = true;
        }
        
    }
}
