using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup5 : Popup
{
    public static Popup instance;
    void Awake() {
        instance = this;
        hide();
    }
    
    void Update()
    {
        if(popup4.instance.done && firstCheck) {
            StartCoroutine(stopHeadAfterSeconds(1f));
            popup4.instance.hide();

        }

        if(secondCheck && anyInput()) {
            secondCheck = false;
            Head.instance.isMoving = true;

        }

        if(!firstCheck && !secondCheck && FoodManager.instance.getFood().hasGrown()) {
            hide();
            done = true;
        }
        
    }
}
