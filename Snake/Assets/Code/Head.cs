using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Head : MonoBehaviour
{
    public static Head instance;


    [SerializeField] public float MoveSpeed = 150.0f;

    [SerializeField] public float BodySpeed = 7.0f;

    [SerializeField] public float SteerSpeed = 180.0f;
    [SerializeField] public float timeMultiplyer = 180.0f;

    [SerializeField] public GameObject Segment;

    [SerializeField] public int Gap = 10;

    [SerializeField] public Sprite tailSprite;

    [SerializeField] public Sprite bodySprite;

    [SerializeField] public bool isCutscene;

    private List<GameObject> Body;
    private List<Vector3> PositionsHistory;

    public int startLength = 5;
    public bool isMoving;
    private bool isJumping = false;
    private float fallDir = 0;

    private float time = 0;

    [NonSerialized]
    public int length = 0;

    private SpriteRenderer sr;

    public bool isDestroyed = false;

    void Awake()
    {
        instance = this;
        Body = new List<GameObject>();
        PositionsHistory = new List<Vector3>();
        sr = this.GetComponent<SpriteRenderer>();
    }

    public void DestroyWorm() {
        Debug.Log("destroying worm");
        for(int i = 0; i < gameObject.transform.childCount; ++i)
        {
            Debug.Log($"{i} segment destroyed");

            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
        foreach(GameObject segment in Body) {
            Destroy(segment);
        }
        Body.Clear();
        length = 0;
        Destroy(this.gameObject);
        //Destroy(this);
    }

    async void Start()
    {

        Debug.Log("HEAD START");
        isMoving = true;
        time = 0;
        for (int i = 0; i < startLength; i++)
        {
            // if(transform == null) {
            //     Debug.Log("TRANSFORM OBJECT IS NULL");
            // }
            // if(gameObject == null) {
            //     Debug.Log("GAME OBJECT IS NULL");
            // }
            // if(instance == null) {
            //     Debug.Log("INSTANCE IS NULL");
            // }
            if(this == null) {
                Debug.Log("HEAD IS NULL");
            } else {
                Debug.Log("trying to grow...");
                Grow();
            }
        }
        length -= startLength;
        await RetardedGrowth();
        //SceneManager.sceneLoaded += OnSceneLoaded;
        //Score.instance.updateText();
        //LevelProgress.instance.updateText();
    }

    /** Spawn body segment*/
    public void Grow() {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(Segment);

        if(Body.Count == 0 ) {
            body.transform.position = this.transform.position;
        } else {
            body.transform.position = Body.Last().transform.position;
        }

        if(Body.Count < startLength) {
           body.tag = "initial";
        }

        Body.Add(body);
        length++;

        Ass.instance.updateCap(Body.Count);
    }


    // code stolen from : 
    // https://www.youtube.com/watch?v=iuz7aUHYC_E
    void FixedUpdate() { 
        time += Time.deltaTime;
        //Debug.Log(length);
        Color storedDirtColor = new Color(1, 1, 1, 1);

        storedDirtColor = Type.getInstance(Ass.instance.storedType).GetColor();

        //Debug.Log(storedDirtColor);
        sr.color = storedDirtColor;

        if (!isMoving) {
            return;
        }

        
        MoveSpeed = Upgrades.instance.applyBoost();
        // Move forward
        transform.position += transform.right * MoveSpeed * Time.deltaTime;

        // Steer
        if(isCutscene) {
            transform.Rotate(Vector3.back * MathF.Sin(time * timeMultiplyer) * SteerSpeed);
        } else if (!isJumping )
        {
            SteerSpeed = Upgrades.instance.upgradeTurning();

            float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
            transform.Rotate(Vector3.back * steerDirection * SteerSpeed * Time.deltaTime);
        }

        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        
        int tempGap = (int) (Gap / Time.deltaTime / 100);
        //Debug.Log($"gap = {tempGap}, max = {PositionsHistory.Count}, deltaTime = {Time.deltaTime}");

        foreach (GameObject body in Body) {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * tempGap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);
            //body.transform.Rotate(Vector3.right * 90);
            body.transform.Rotate(Vector3.up * 90);

            SpriteRenderer tempSR = Body[index].GetComponent<SpriteRenderer>();
            tempSR.color = storedDirtColor;

            if(index != Body.Count - 1) {
                tempSR.sprite = bodySprite;

            } else 
            {
                tempSR.flipX = true;
                tempSR.sprite = tailSprite;

            }

            index++;
        }

        if (Body.Count > 0)
        {
            // Update dirt spawner's position
            Ass.instance.setTransform(Body.Last().transform);
        }
    }

    private async void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        if (!isDestroyed)
        {
            Ass.instance.dirtCount = 0;
            PositionsHistory.Clear();
            foreach (GameObject body in Body)
            {
                if (body != null)
                {
                    Destroy(body);
                }
            }
            Body.Clear();
            for (int i = 0; i < startLength; i++)
            {
                if(this == null) {
                    Debug.Log("HEAD IS NULL (grow in OnSceneLoaded)");
                } else {
                    Debug.Log("trying to grow...");
                    Grow();
                }
            }
            length -= startLength;
            await RetardedGrowth(); 
        }
    }

    private async Task RetardedGrowth()
    {
        Debug.Log("RETARDED GROW " + length);
        // Spawning body after load new level
        await Task.Delay(700); // Value calculated by eye ;)
        isJumping = false; // Protection from blocking movement
        int temp = length;
        for (int i = 0; i < temp - startLength; i++)
        {
            Grow();
        }
        length = temp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "body" || other.tag == "obstacle")
        {
            if(Upgrades.instance.dying())
            {
                Debug.Log("DEATH");
                Debug.Log(other.tag);
                StartCoroutine(Death());
            }
            
                    
        }

        // if (other.tag == "food")
        // {
        //     Food.instance.Spawn();
        //     Grow();
        // }
        if (other.tag == "respawnedDirt")
        {
            //Debug.Log("DEATH");
            //StartCoroutine(Death());        
        }
        if (other.tag == "GravityHorizontal")
        {
            if (Mathf.Abs(transform.rotation.w) > Mathf.Abs(transform.rotation.z))
            {
                fallDir = 0.5f;
            }
            else
            {
                fallDir = -0.5f;
            }
            if (transform.rotation.z < 0.0f)
            {
                fallDir *= -1.0f;
            }
            isJumping = true;
        }


        if (other.tag == "GravityVertical")
        {
            if (transform.rotation.z < 0.0f)
            {
                fallDir = 0.5f;
            }
            else
            {
                fallDir = -0.5f;
            }
            if (Mathf.Abs(transform.rotation.w) < Mathf.Abs(transform.rotation.z))
            {
                fallDir *= -1.0f;
            }
            isJumping = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.tag == "GravityHorizontal" || other.tag == "GravityVertical") && isMoving)
        {
            transform.Rotate(Vector3.back * fallDir * SteerSpeed * Time.deltaTime);
            isJumping = true; // Added to prevent bug while changing gravity areas
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "GravityHorizontal" || other.tag == "GravityVertical")
        {
            isJumping = false;
        }
    }

    public IEnumerator Death(bool force = false)
    {
        //do stuff
        Debug.Log("death"); 
        isMoving = false;
        yield return StartCoroutine(DeathManager.instance.triggerDeath());
         //Debug.Log("after anim"); 

        

        //wait for enter to be pressed

        //do stuff once enter is pressed
        Debug.Log("respawning");

        foreach (GameObject seg in Body)
        {
            Destroy(seg);
        }
        Body.Clear();

        if (force)
        {
            Destroy(gameObject);
            instance = null;
        }
        else
        {
            isMoving = true;
        }
        isDestroyed = true;
        PauseMenu.instance.Pause();
        yield return null;
    }
    

}
