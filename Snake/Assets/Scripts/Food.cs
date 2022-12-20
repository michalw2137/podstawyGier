using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static Food instance;

    private SpriteRenderer sr;

    private SFXmanager sfx;

    private FoodParticleManager fpm;

    private SquashManager sm;

    private bool isEaten = false;

    [SerializeField]
    public Sprite seed0, seed1, seed2, seed3, seed4, grown;

    private DirtDetector dirtDetector;

    private bool isRipe = false;

    void Awake()
    {
        instance = this;
    }

    void Start() 
    {
        sr = GetComponent<SpriteRenderer>();
        fpm = GetComponent<FoodParticleManager>();
        sm = GetComponent<SquashManager>();
        sfx = GetComponent<SFXmanager>();
        dirtDetector = transform.GetChild(0).GetComponent<DirtDetector>();
        setSprite(0);
        isRipe = false;

        //Spawn();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "head") {
            //Debug.Log("collision with head");
            if(isRipe && !isEaten){
                fullyGrow();

                Head.instance.Grow();
                // Head.instance.Grow();
                // Head.instance.Grow();

                
                //sr.size *= new Vector2(4, 4);
                //Spawn();
            }
            else {
                //Debug.Log("isnt ripe");
            }
        }
    }

    private void fullyGrow() 
    {
        isEaten = true;
        sfx.playSound(0);
        squash();
        sr.sprite = grown;
        emitParticles(false, 0);
        emitParticles(true, 1);
    }

    public void emitParticles(bool emit, int n) {
        //Debug.Log($"emitting particles: {emit}");
        fpm.setParticling(emit, n);
    }

    private void squash() {
        //Debug.Log("playing animation");
        sm.triggerSquash();
    }

    public void squashIncrease() {
        //Debug.Log("playing animation");
        sm.triggerIncreaseSquash();
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

    public void setSprite(int growthStage)
    {
        if(sr.sprite == grown && growthStage != 0) {
            return;
        }
        if(isRipe)
        {
            sr.sprite = seed4;
            return;
        }
        //Debug.Log($"setting food sprite to seed{growStage}");
        switch(growthStage)
        {
            case 0: 
                if(sr.sprite == seed0) break;
                sr.sprite = seed0; 
                break;
                
            case 1: 
                if(sr.sprite == seed1) break;
                sfx.playSound(1);
                squash();
                sr.sprite = seed1; 
                break;

            case 2: 
                if(sr.sprite == seed2) break;
                sfx.playSound(1);
                squash();
                sr.sprite = seed2; 
                break;

            case 3: 
                if(sr.sprite == seed3) break;
                sfx.playSound(1);
                squash();
                sr.sprite = seed3; 
                break;
            case 4: 
                if(sr.sprite == seed4) break;
                sfx.playSound(1);
                squash();
                sr.sprite = seed4; 
                emitParticles(true, 0);
                
                break;
        }
    }
}
