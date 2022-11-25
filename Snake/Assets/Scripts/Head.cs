using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Head : MonoBehaviour
{
    public static Head instance;


    [SerializeField]
    public float MoveSpeed = 150.0f;

    [SerializeField]
    public float BodySpeed = 7.0f;

    [SerializeField]
    public float SteerSpeed = 180.0f;

    [SerializeField]
    public GameObject Segment;

    [SerializeField]
    public int Gap = 10;

    [SerializeField]
    public Sprite tailSprite;

    [SerializeField]
    public Sprite bodySprite;

    private List<GameObject> Body;
    private List<Vector3> PositionsHistory;

    public bool isMoving;
    private bool isJumping = false;
    private float fallDir = 0;

    private SpriteRenderer sr;

    void Awake()
    {
        instance = this;
        Body = new List<GameObject>();
        PositionsHistory = new List<Vector3>();
        sr = this.GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        isMoving = true;

        Grow();
        Grow();
        Grow();
        Grow();
        Grow();
        Grow();

        foreach(GameObject segment in Body) {
            segment.tag = "initial";
        }

        
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

        if(Body.Count < 5) {
           body.tag = "initial";
        }
        DontDestroyOnLoad(body);
        Body.Add(body);

        Ass.instance.updateCap(Body.Count);
    }


    // code stolen from : 
    // https://www.youtube.com/watch?v=iuz7aUHYC_E
    void FixedUpdate() { 
        Color storedDirtColor = new Color(1, 1, 1, 1);
        try
        {
            storedDirtColor = Ass.instance.storedType.GetColor(Status.fertilizer);
        } catch {
            Debug.Log("nullptr exception");
        }

        Debug.Log(storedDirtColor);
        sr.color = storedDirtColor;

        if(!isMoving) {
            return;
        }

        // Move forward
        transform.position += transform.right * MoveSpeed * Time.deltaTime;

        // Steer
        if (!isJumping)
        {
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

        // Update dirt spawner's position
        Ass.instance.setTransform(Body.Last().transform);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "body")
        {
            // TODO: i dont think i works properly all the time
            Debug.Log("DEATH");
            StartCoroutine(Death());        
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
        if (other.tag == "GravityHorizontal" || other.tag == "GravityVertical")
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


    IEnumerator Death()
    {
        //do stuff
        Debug.Log("death"); 

        isMoving = false;

        //wait for enter to be pressed
        while(!Input.anyKey)
        {
            yield return null;
        }
    
        //do stuff once enter is pressed
        Debug.Log("respawning");

        SceneManager.LoadScene(0);
        foreach(GameObject seg in Body)
        {
            Destroy(seg);
        }
        Destroy(gameObject);
    }

}
