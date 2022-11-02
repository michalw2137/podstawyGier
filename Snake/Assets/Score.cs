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
        dirtCollected.text = $"dirt stored: {Ass.instance.dirtCount}";
    }

    public void updateText() {
        dirtCollected.text = $"dirt stored: {Ass.instance.dirtCount}";
    }
   
}
