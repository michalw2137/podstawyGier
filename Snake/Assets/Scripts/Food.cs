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

    private DirtDetector dirtDetector;

    private bool isRipe = false;

    void Awake()
    {
        instance = this;
        sr = GetComponent<SpriteRenderer>();
    }

    void Start() 
    {
        dirtDetector = transform.GetChild(0).GetComponent<DirtDetector>();
        this.tag = "food";
        Spawn();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "head") {
            //Debug.Log("collision with head");
            if(isRipe){
                Head.instance.Grow();
                Head.instance.Grow();
                Head.instance.Grow();

                Spawn();
            }
            else {
                //Debug.Log("isnt ripe");
            }
        }
    }

    public void Spawn() 
    {
        isRipe = false;
        setSprite(0);

        Vector2 start = FoodManager.instance.smallerCords;
        Vector2 end = FoodManager.instance.biggerCords;
      
        Vector3 position = new Vector3(0, 0, 0);

        position.x = Random.Range(start.x, end.x); 
        position.y = Random.Range(start.y, end.y); 
        // Debug.Log($"X range: {start.x} {end.x}");
        // Debug.Log($"Y range: {start.y} {end.y}");

        // Debug.Log($"new food position: {position}");

        this.transform.position = position;
    }

    public void setRipe(bool ripe)
    {
        isRipe = ripe;
    }

    public void setSprite(int growStage)
    {
        if(isRipe)
        {
            sr.sprite = seed3;
            return;
        }
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
