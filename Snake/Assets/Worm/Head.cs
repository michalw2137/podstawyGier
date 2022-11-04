using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Head : MonoBehaviour
{
    [SerializeField]
    public float Speed = 1000.0f;

    /** Value which defines space between body segments */
    [SerializeField]
    public float SegmentSpace = 0.2f;

    /** Sensitivity of how much snake will rotate on holding buttons */
    [SerializeField]
    public float RotationSensivity = 120.0f;

    [SerializeField]
    public GameObject Segment;

    List<GameObject> Body;

    /** Value to count whether space between segments is enough */
    float SpaceCounter = 0.0f;

    bool toSpawn;
    public bool isMoving;

    public static Head instance;

    void Start()
    {
        // Components check
        if (!GetComponent<PathMarker>())
        {
            gameObject.AddComponent<PathMarker>();
        }
        if (!GetComponent<Rigidbody2D>())
        {
            gameObject.AddComponent<Rigidbody2D>();
            GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        }

        Body.Add(gameObject);

        isMoving = true;
        toSpawn = false;
    }

    void Awake()
    {
        instance = this;

        Body = new List<GameObject>();
    }

    /** Update velocity and rotation*/
    void WormMovement()
    {
        if (Input.GetAxis("Horizontal") != 0.0f)
        {
            GetComponent<Rigidbody2D>().velocity = Body[0].transform.right * Speed * Time.deltaTime;
            Body[0].transform.Rotate(new Vector3(0, 0, -RotationSensivity * Time.deltaTime * Input.GetAxis("Horizontal")));
        }

        if (Body.Count > 1)
        {
            // Body path following
            for (int i = 1; i < Body.Count; ++i)
            {
                PathMarker pathMarker = Body[i - 1].GetComponent<PathMarker>();
                Body[i].transform.position = pathMarker.markers[0].Position;
                Body[i].transform.rotation = pathMarker.markers[0].Rotation;
                pathMarker.markers.RemoveAt(0);
            }
        }
    }

    /** Spawn body segment*/
    private void Grow()
    {
        //Path marker activation
        PathMarker pathMarker = Body[Body.Count - 1].GetComponent<PathMarker>();

        if (SpaceCounter == 0.0f)
        {
            pathMarker.ClearMarkers();

        }

        SpaceCounter += Time.deltaTime;

        if (SpaceCounter > SegmentSpace)
        {
            GameObject temp = Instantiate(Segment, pathMarker.markers[0].Position, pathMarker.markers[0].Rotation);
            // Check components
            if (!temp.GetComponent<PathMarker>())
            {
                temp.AddComponent<PathMarker>();
            }
            if (!temp.GetComponent<Rigidbody2D>())
            {
                temp.AddComponent<Rigidbody2D>();
                temp.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            }

            Body.Add(temp);
            temp.GetComponent<PathMarker>().ClearMarkers();
            SpaceCounter = 0.0f;
            toSpawn = false;
        }
    }

    void FixedUpdate() 
    { // order is critical! spawn > update body > move head

        //DEBUGGING ! WARNING - SHIT CODE AHEAD
        if(Body.Count < 5) {
            Grow();
        }


        //DEBUGGING ! WARNING - SHIT CODE BEFORE

        if (!isMoving)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }

        if (toSpawn)
        {
            Grow();
        }

        /** Head movement */
        WormMovement();
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "obstacle")
        {
            StartCoroutine(Death());
        }
        if (other.tag == "body")
        {
            //StartCoroutine(Death());        
        }
        if (other.tag == "map")
        {
            Debug.Log("touched map");
            StartCoroutine(Death());        
        }
        if (other.tag == "food")
        {
            toSpawn = true;
        }

    }
 

    IEnumerator Death()
    {
    
        //do stuff
        Debug.Log("death"); 

        isMoving = false;

        //wait for space to be pressed
        while(!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
    
        //do stuff once space is pressed
        Debug.Log("respawning");

        SceneManager.LoadScene(0);
    
    }

    public Transform getLastSegmentPosition() {
        return Body[Body.Count - 1].transform;
    }
    

   
}
