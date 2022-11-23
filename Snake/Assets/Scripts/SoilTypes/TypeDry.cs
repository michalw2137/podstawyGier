using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeDry : Type
{
    public static Type instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        type = Types.dry;
    }

    override public string ToString() {
        return "Dry dirt";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
