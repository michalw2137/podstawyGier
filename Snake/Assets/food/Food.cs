using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static Food instance;

    private SpriteRenderer sr;

    void Awake()
    {
        instance = this;
        sr = GetComponent<SpriteRenderer>();
    }

    void Start() 
    {
        Spawn();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        // if (other.tag == "initial") {
        //     Debug.Log("spawning food...");
        //     Spawn();
        // } 
        // if (other.tag == "body") {
        //     Spawn();
        // }
        if (other.tag == "head") {
            if(DirtDetector.instance.isRipe()){
                Head.instance.Grow();
                Head.instance.Grow();
                Head.instance.Grow();

                Spawn();
                DirtDetector.instance.reset();
            }
            else {
               // Debug.Log("isnt ripe");
            }
        }
    }

    public void Spawn() 
    {
        sr.color = DirtDetector.instance.unripeColor;

        Vector2 start = DirtSpawner.instance.start;
        Vector2 end = DirtSpawner.instance.end;
      
        Vector3 position = new Vector3(0, 0, 0);

        position.x = Random.Range(start.x + 150, end.x - 150); 
        position.y = Random.Range(start.y + 150, end.y - 150); 
        // Debug.Log($"X range: {start.x} {end.x}");
        // Debug.Log($"Y range: {start.y} {end.y}");

        // Debug.Log($"new food position: {position}");

        this.transform.position = position;
    }

    public void setColor(Color color)
    {
        sr.color = color;
    }
}
