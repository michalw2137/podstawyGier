using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] public bool isCutscene = true;
    // Start is called before the first frame update
    public static StateManager instance;

    void Awake() {
        instance = this;
    }

    void Start()
    {
        Head.instance.isCutscene = isCutscene;
        Head.instance.isMoving = true;
        Ass.instance.storedType = TypeCutscene.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
