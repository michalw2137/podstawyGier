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
        dirtCount = 0;
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        
    }

    public bool canChangeDirtCount(int count) 
    {
        if (dirtCount == 0 && count < 0)
        {
            //Debug.Log($"FALSE dirtCount = {dirtCount}, count = {count}");
            return false;
        }

        if (dirtCount == dirtCap && count > 0)
        {
            //Debug.Log($"FALSE dirtCount = {dirtCount}, count = {count}");

            return false;
        }

        //Debug.Log($"TRUE dirtCount = {dirtCount}, count = {count}");

        dirtCount += count;
        Score.instance.updateText();
        return true;
            
    }

    public void setTransform(Transform transform) 
    {
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;
    }


    public void updateCap(int size)
    {
        dirtCap = dirtCapMultiplier * size;
        Debug.Log($"current cup = {dirtCap}");
    }

    public int getMaxCapacity()
    {
        return dirtCap;
    }

}
