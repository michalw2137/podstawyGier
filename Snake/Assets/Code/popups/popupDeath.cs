using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupDeath : Popup
{
    public static Popup instance;
    void Awake() {
        instance = this;
        hide();
    }
    
    void Start()
    {
        StartCoroutine(stopHeadAfterSeconds(0.5f));
        show();
    }

    // Update is called once per frame
    void Update()
    {
        if(anyInput() && !done) {
            hideDelayed();
            done = true;
            Head.instance.isMoving = true;
        }
    }
}
