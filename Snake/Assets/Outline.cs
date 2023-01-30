using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outline : MonoBehaviour
{

    public int foodId;
    public Types type;
    
    bool done = false;

    public Image img;

    void Awake() {
        img = GetComponent<Image>();
    }



}
