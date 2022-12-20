using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeNormal : Type
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
