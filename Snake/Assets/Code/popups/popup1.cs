using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup1 : Popup
{

    public static Popup instance;
    void Awake() {
        instance = this;
        hide();
    }
    
    void Start()
    {
        StartCoroutine(stopHeadAfterSeconds(0.05f));
        show();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0 && !done) {
            hide();
            done = true;
            Head.instance.isMoving = true;
        }
    }

}