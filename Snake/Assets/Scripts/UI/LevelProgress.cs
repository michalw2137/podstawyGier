using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    public Text textField;
    public static LevelProgress instance;

    private bool onlyOnce = true;

    void Awake() {
        instance = this;
    }

    void Start()
    {
        updateText();
    }

    public void updateText() {
        if (Head.instance == null) {
            return;
        }

        //string state = "";
        if(Exit.instance.isOpen()) {
           // state = "is open" ;
            LevelCompleteParticleManager.instance.setParticling(true);
            if(onlyOnce)
            {
                Ass.instance.sfx.playSoundWithoutRepeat(2);
                onlyOnce = false;
            }
        } else {
            //state = "is closed" ;
            onlyOnce = true;
            LevelCompleteParticleManager.instance.setParticling(false);
        } 
        int length = Head.instance.length;
        int requiredLength = Exit.instance.RequiredLength;
        textField.text = $"Length: {length}/{requiredLength}";
    }
   

    // Update is called once per frame
    void Update()
    {
        updateText();
    }
}
