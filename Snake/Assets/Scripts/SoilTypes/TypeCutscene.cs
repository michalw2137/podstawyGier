using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeCutscene : Type
{
    public static Type instance;

    // Start is called before the first frame update
    void Awake() {
        Debug.Log("cutscene type awake");
        if(instance == null) {
            Debug.Log("cutscene type instance is null");
            instance = this;

            DontDestroyOnLoad(this);
        } else {
            Debug.Log("cutscene type destroy game object");
            Destroy(gameObject);
        }
        type = Types.cutscene;
    }

    void Start() {
        //Awake();
        Debug.Log("CUTSCENE TYPE START");
    }

    override public string ToString() {
        return "Cutscene dirt";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
