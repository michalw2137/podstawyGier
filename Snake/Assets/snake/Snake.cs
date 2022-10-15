using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    Vector3 position;

    Vector2 direction;
    Vector2 previoursDirection;

    [SerializeField] GameObject segment;
    List<GameObject> body;

    bool toSpawn;
    public bool isMoving;

    public static Snake instance;

    void Awake() {
        instance = this;
        position = new Vector3(0, 0, 0);

        direction =  Vector2.right;
        previoursDirection = Vector2.right;

        body = new List<GameObject>();
    }

    void Start() {
        isMoving = true;
        toSpawn = false;
        transform.position = position;
        body.Add(this.gameObject);
    }

    void Update()
    {
        void readControls() {
            if(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) {
                return;
            }

            if(Input.GetAxis("Horizontal") > 0 && previoursDirection != Vector2.left) {
                direction = Vector2.right;
                return;
            }
            if(Input.GetAxis("Horizontal") < 0 && previoursDirection != Vector2.right) {
                direction = Vector2.left;
                return;
            }
            if(Input.GetAxis("Vertical") > 0 && previoursDirection != Vector2.down) { 
                direction = Vector2.up;
                return;
            }
            if(Input.GetAxis("Vertical") < 0 && previoursDirection != Vector2.up) {
                direction = Vector2.down;
                return;
            }
        }

        readControls();        
    }

    void FixedUpdate() { // order is critical! spawn > update body > move head
        if (!isMoving) {
            return;
        }

        if (toSpawn) {
            grow();
            toSpawn = false;
        }
        
        void updateBody() {
            for (int i = body.Count - 1; i > 0; i--) {
                body[i].transform.position = body[i-1].transform.position;
            }
        }
        updateBody();

        void moveHead() {
            this.position.x += this.direction.x;
            this.position.y += this.direction.y;

            this.transform.position = position;

            previoursDirection = direction;  
        }
        moveHead();              
    }

    private void grow() {
        GameObject temp = Instantiate(segment);
            
        temp.transform.position = body[body.Count - 1].transform.position;
        
        body.Add(temp);

        Score.instance.addPoints(1);
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "obstacle") {
            StartCoroutine(Death());
        }
        if (other.tag == "body") {
            StartCoroutine(Death());        
        }
        if (other.tag == "food") {
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

    public bool touches(Vector3 point) {
        foreach (GameObject segment in body) {
            if (segment.transform.position == point) {
                return true;
            }
        }
        return false;
    }

    public bool closeToHead(Vector3 point, int distance) {
        if (System.Math.Abs(position.x - point.x) <= distance) {
            return true;                
        }
        if (System.Math.Abs(position.y - point.y) <= distance) {
            return true;                
        }
        return false;
    }

    

   
}
