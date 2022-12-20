using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text dirtCollected;

    public static Score instance;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        updateText();
    }

    public void updateText() {
        dirtCollected.text = $"{Ass.instance.storedType} stored: {Ass.instance.dirtCount} / {Ass.instance.getMaxCapacity()}";
    }
   
}
