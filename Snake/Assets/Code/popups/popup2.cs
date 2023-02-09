using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup2 : Popup
{
    public static Popup instance;
    void Awake() {
        instance = this;
        hide();
    }
    
    void Update()
    {
        if(popup1.instance.done && firstCheck) {
            StartCoroutine(stopHeadAfterSeconds(2f));
            popup1.instance.hide();
        }

        if(secondCheck && Input.GetAxis("Fire2") != 0) {
            Head.instance.isMoving = true;

            secondCheck = false;
        }

        if(!done && !firstCheck && !secondCheck) {
            if(Ass.instance.isFull()) {
                hide();
                done = true;
            }
        }
    }


}