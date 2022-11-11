using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static Food instance;

    private SpriteRenderer sr;

    [SerializeField]
    public Sprite seed0;

    [SerializeField]
    public Sprite seed1;

    [SerializeField]
    public Sprite seed2;

    [SerializeField]
    public Sprite seed3;

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
            Debug.Log("collision with head");
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
        sr.sprite = seed0;
        sr.color = DirtDetector.instance.unripeColor;

        Vector2 start = DirtSpawner.instance.start;
        Vector2 end = DirtSpawner.instance.end;
      
        Vector3 position = new Vector3(0, 0, 0);

        position.x = Random.Range(start.x + 50, end.x - 50); 
        position.y = Random.Range(start.y + 50, end.y - 50); 
        // Debug.Log($"X range: {start.x} {end.x}");
        // Debug.Log($"Y range: {start.y} {end.y}");

        // Debug.Log($"new food position: {position}");

        this.transform.position = position;
    }

    public void setColor(Color color)
    {
        sr.color = color;
    }

    public void setSprite(int growStage)
    {
        //Debug.Log($"setting food sprite to seed{growStage}");
        switch(growStage)
        {
            case 0: 
                if(sr.sprite == seed0) break;

                sr.sprite = seed0; 
                break;
                
            case 1: 
                if(sr.sprite == seed1) break;

                sr.sprite = seed1; 
                break;

            case 2: 
                if(sr.sprite == seed2) break;

                sr.sprite = seed2; 
                //transform.position = new Vector3(transform.position.x, transform.position.y + 15, transform.position.z);
                break;

            case 3: 
                if(sr.sprite == seed3) break;

                sr.sprite = seed3; 
                //transform.position = new Vector3(transform.position.x, transform.position.y + 25, transform.position.z);
                break;
        }
    }
}
