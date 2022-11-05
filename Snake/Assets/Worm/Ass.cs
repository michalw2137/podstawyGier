using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ass : MonoBehaviour
{
    public static Ass instance;

    public int dirtCount {get; set;}

    void Awake() {
        instance = this;
    }

    void Start()
    {
        dirtCount = 0;
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        
    }

    public void changeDirtCount(int count) 
    {
        dirtCount += count;
        Score.instance.updateText();
    }

    public void setTransform(Transform transform) 
    {
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;
    }

}
