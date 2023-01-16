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
    public bool isJumping = false;

    private float time = 0;

    [NonSerialized]
    public int length = 0;

    private SpriteRenderer sr;

    public bool isDestroyed = false;

    void Awake()
    {
        Debug.Log("HEAD AWAKE");
        instance = this;
        isMoving = true;
        Body = new List<GameObject>();
        PositionsHistory = new List<Vector3>();
        sr = this.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Debug.Log("HEAD START");
        time = 0;
        for (int i = 0; i < startLength; i++) {
            Grow();
        }
    }


    /** Spawn body segment*/
    public void Grow() {
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

    //Set color
        Color storedDirtColor = Ass.instance.storedType.GetColor();
        sr.color = storedDirtColor;

        if (!isMoving) {
            return;
        }

    //Movement    
        Steer();
        Move();

    //Update segments' sprites
        Body.Last().GetComponent<SpriteRenderer>().sprite = tailSprite;

        if(Body.Count() >= 2) {
            Body.ElementAt(Body.Count() - 2).GetComponent<SpriteRenderer>().sprite = bodySprite;
        }

    
    // Update dirt spawner's position
        if (Body.Count > 0) {
            Ass.instance.setTransform(Body.Last().transform);
        }

    }

    private void Steer() {
        // Steer
        if(isCutscene) {
            transform.Rotate(Vector3.back * MathF.Sin(time * timeMultiplyer) * SteerSpeed);
        } else if (!isJumping )
        {
            float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
            transform.Rotate(Vector3.back * steerDirection * SteerSpeed * Time.deltaTime);
        }

    }

    private void Move() {
        // Move forward
        transform.position += transform.right * MoveSpeed * Time.deltaTime;

        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        
        foreach (GameObject body in Body) {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);
            //body.transform.Rotate(Vector3.right * 90);
            body.transform.Rotate(Vector3.up * 90);

            index++;
        }
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "body")
        {
            // TODO: i dont think i works properly all the time
            Debug.Log("DEATH");
            Debug.Log(other.tag);
            StartCoroutine(Death());        
        }
        if(other.tag != "deafaultDirt") {

            Debug.Log($"HEAD COLLIDED WITH {other.tag}");
        }
    }

    public IEnumerator Death(bool force = false)
    {
        //do stuff
        Debug.Log("death"); 
        isMoving = false;
        yield return StartCoroutine(triggerDeath());
       

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

    public IEnumerator triggerDeath() 
    {
        Animator anim = GetComponent<Animator>();
        anim.Play("Death");

        float animationLength = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animationLength);
        //Debug.Log("Done Playing");
    }

}
