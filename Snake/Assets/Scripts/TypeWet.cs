using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeWet : Type
{
    public static Type instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        type = Types.wet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
