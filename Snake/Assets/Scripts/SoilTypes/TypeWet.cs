using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeWet : Type
{
    public static Type instance;

    // Start is called before the first frame update
    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
        type = Types.wet;
    }

    override public string ToString() {
        return "Wet dirt";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
