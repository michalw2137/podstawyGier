using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup6 : Popup
{
    public static Popup instance;
    void Awake() {
        instance = this;
        hide();
    }
    
    void Update()
    {
        if(popup5.instance.done && firstCheck) {
            StartCoroutine(stopHeadAfterSeconds(1f));
            popup5.instance.hide();

        }

        if(secondCheck && anyInput()) {
            Head.instance.isMoving = true;

            secondCheck = false;
        }

        
    }
}
