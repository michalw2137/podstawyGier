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
        transform.position = Head.instance.getLastSegmentPosition().position;
        transform.rotation = Head.instance.getLastSegmentPosition().rotation;

    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        
    }

    public void changeDirtCount(int count) 
    {
        dirtCount += count;
        Score.instance.updateText();
    }

}
