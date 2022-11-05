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


    private List<GameObject> Body;
    private List<Vector3> PositionsHistory;

    public bool isMoving;

    void Awake()
    {
        instance = this;
        Body = new List<GameObject>();
        PositionsHistory = new List<Vector3>();
    }

    void Start()
    {
        isMoving = false;

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
    private void Grow()
    {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(Segment);
        Body.Add(body);
    }


    // code stolen from : 
    // https://www.youtube.com/watch?v=WZpdtNOisvA
    void Update() 
    { 
        if(Input.anyKey) {
            isMoving = true;
        }
        if(!isMoving) {
            return;
        }

        // Move forward
        transform.position += transform.right * MoveSpeed * Time.deltaTime;

        // Steer
        float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
        transform.Rotate(Vector3.back * steerDirection * SteerSpeed * Time.deltaTime);

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
        // Update dirt spawner's position
        Ass.instance.setTransform(Body.Last().transform);

    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "body")
        {
            // TODO: i dont think i works properly all the time
            Debug.Log("DEATH");
            StartCoroutine(Death());        
        }
        if (other.tag == "food")
        {
            Food.instance.Spawn();
            Grow();
        }

    }
 

    IEnumerator Death()
    {
    
        //do stuff
        Debug.Log("death"); 

        isMoving = false;

        //wait for enter to be pressed
        while(!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
    
        //do stuff once enter is pressed
        Debug.Log("respawning");

        SceneManager.LoadScene(0);
    
    }

}
