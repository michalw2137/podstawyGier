using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    [SerializeField]
    public int Step;

    /** Value which defines space between body segments*/
    [SerializeField]
    public float SegmentSize;

    /** Sensitivity of how much snake will rotate on holding buttons*/
    [SerializeField]
    public float RotationSensivity;

    [SerializeField]
    public GameObject Segment;

    List<GameObject> body;

    /** Sensitivity of how much snake will rotate on holding buttons*/
    private float DirectionAngle;
    private Vector3 Position;

    bool toSpawn;
    public bool isMoving;

    public static Snake instance;

    void Start()
    {
        isMoving = true;
        toSpawn = false;
        Position = transform.position;
        body.Add(this.gameObject);
    }

    void Awake()
    {
        instance = this;
        Position = new Vector3(0, 0, 0);
        DirectionAngle = 0.0f;

        body = new List<GameObject>();
    }

    void Update()
    {
        void readControls() 
        {
            if (Input.GetAxis("Horizontal") == 0.0f)
            {
                return;
            }
            else if (Input.GetAxis("Horizontal") < 0.0f)
            {
                DirectionAngle += RotationSensivity * Time.deltaTime;
                DirectionAngle -= DirectionAngle > 180.0f ? 360.0f : 0.0f;
                return;
            }
            else if (Input.GetAxis("Horizontal") > 0.0f)
            {
                DirectionAngle -= RotationSensivity * Time.deltaTime;
                DirectionAngle += DirectionAngle < -180.0f ? 360.0f : 0.0f;
                return;
            }
        }

        readControls();        
    }

    void FixedUpdate() 
    { // order is critical! spawn > update body > move head
        if (!isMoving)
        {
            return;
        }

        if (toSpawn)
        {
            grow();
            toSpawn = false;
        }
        
        void updateBody() 
        {
            for (int i = 1; i < body.Count; ++i) 
            {
                UpdateSegment(i, body[i - 1].transform.position.x, body[i - 1].transform.position.y);
            }
        }
        updateBody();

        /** Head movement */
        void Move()
        {
            Position.x += Mathf.Cos(Mathf.Deg2Rad * DirectionAngle) * Step;
            Position.y += Mathf.Sin(Mathf.Deg2Rad * DirectionAngle) * Step;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, DirectionAngle);
            transform.position = Position;
        }

        Move();
    }

    /** Update position and rotation of body segments */
    void UpdateSegment(int i, float xin, float yin)
    {
        float dx = xin - body[i].transform.position.x;
        float dy = yin - body[i].transform.position.y;
        float angle = Mathf.Atan2(dy, dx);
        Vector2 pos;
        pos.x = xin - Mathf.Cos(angle) * SegmentSize;
        pos.y = yin - Mathf.Sin(angle) * SegmentSize;
        body[i].transform.position = pos;
        body[i].transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }



    private void grow() 
    {
        GameObject tempObject = Instantiate(Segment);
        Vector3 tempPos = Vector3.zero;

        tempPos.x = Mathf.Cos(Mathf.Deg2Rad * DirectionAngle) * SegmentSize;
        tempPos.y = Mathf.Sin(Mathf.Deg2Rad * DirectionAngle) * SegmentSize;

        tempObject.transform.position = body[body.Count - 1].transform.position - tempPos;

        body.Add(tempObject);

    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "obstacle")
        {
            StartCoroutine(Death());
        }
        if (other.tag == "body")
        {
            StartCoroutine(Death());        
        }
        if (other.tag == "map")
        {
            Debug.Log("touched map");
            StartCoroutine(Death());        
        }
        if (other.tag == "food")
        {
            Map.instance.spawnRandomWall();
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

    public bool touches(Vector3 point) 
    {
        foreach (GameObject segment in body) 
        {
            if (segment.transform.position == point) 
            {
                return true;
            }
        }
        return false;
    }

    public bool closeToHead(Vector3 point, int distance) {
        if (System.Math.Abs(Position.x - point.x) <= distance) {
            return true;                
        }
        if (System.Math.Abs(Position.y - point.y) <= distance) {
            return true;                
        }
        return false;
    }

    public Vector3 getLastSegmentPosition() {
        return body[body.Count - 1].transform.position;
    }
    

   
}
