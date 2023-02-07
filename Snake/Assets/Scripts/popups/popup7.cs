using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popup7 : Popup
{
    public static Popup instance;
    void Awake() {
        instance = this;
        hide();
    }

    

    
}
