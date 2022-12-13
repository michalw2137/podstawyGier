using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    public Text textField;
    public static LevelProgress instance;

    void Awake() {
        instance = this;
    }

    void Start()
    {
        updateText();
    }

    public void updateText() {
        string state = "";
        if(Exit.instance.isOpen()) {
            state = "is open" ;
        } else {
            state = "is closed" ;
        } 
        int length = Head.instance.length;
        int requiredLength = Exit.instance.RequiredLength;
        textField.text = $"Length: {length}/{requiredLength}     Exit {state}";
    }
   

    // Update is called once per frame
    void Update()
    {
        //"Length: 0/0 - Exit closed"
    }
}
