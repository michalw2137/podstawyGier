using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeNormal : Type
{
    public static Type instance;

    // Start is called before the first frame update
    void Awake() {
        instance = this;
        
        type = Types.normal;
    }

    override public string ToString() {
        return "Normal dirt";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
