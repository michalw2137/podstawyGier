using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static Food instance;

    void Awake()
    {
        instance = this;
    }

    void Start() 
    {
        spawn();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "head") {
            //Debug.Log("spawning food...");
            spawn();
        } 
        if (other.tag == "body") {
            spawn();
        }
    }

    void spawn() 
    {
        Vector2 start = DirtSpawner.instance.start;
        Vector2 end = DirtSpawner.instance.end;
      
        Vector3 position = new Vector3(0, 0, 0);

        position.x = Random.Range(start.x, end.x); 
        position.y = Random.Range(start.y, end.y); 
        // Debug.Log($"X range: {start.x} {end.x}");
        // Debug.Log($"Y range: {start.y} {end.y}");

        // Debug.Log($"new food position: {position}");

        this.transform.position = position;
    }
}
