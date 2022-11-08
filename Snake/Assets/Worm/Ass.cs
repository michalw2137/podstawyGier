using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ass : MonoBehaviour
{
    public static Ass instance;

    public int dirtCount {get; set;}

    [SerializeField]
    public int dirtCapMultiplier = 100;

    private int dirtCap;

    void Awake() {
        instance = this;
    }

    void Start()
    {
        dirtCap = dirtCapMultiplier * Head.instance.getSize();
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
        if(dirtCount < dirtCap)
            dirtCount += count;
        Score.instance.updateText();
    }

    public void setTransform(Transform transform) 
    {
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;
    }

}
