using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatingDirt : MonoBehaviour
{
    public static eatingDirt instance;

    public int dirtCount {get; set;}

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        dirtCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Snake.instance.getLastSegmentPosition();
    }

    public void changeDirtCount(int count) {
        dirtCount += count;
        Score.instance.updateText();
    }

    void OnTriggerEnter2D(Collider2D other) {
        
    }

}
