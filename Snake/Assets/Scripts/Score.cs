using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text dirtCollected;

    public static Score instance;

    void Awake() {
        instance = this;
    }

    void Start()
    {
        updateText();
    }

    public void updateText() {
        dirtCollected.text = $"{Ass.instance.storedType} stored: {Ass.instance.dirtCount} / {Ass.instance.getMaxCapacity()}";
    }
   
}
