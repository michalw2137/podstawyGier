using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject wall;

    List<GameObject> stationaryWalls;
    List<GameObject> movingWalls;

    [SerializeField] int startingWalls = 1;

    [SerializeField] public Vector2Int size;

    private float time = 0;
    [SerializeField] private float delay = 2f;


    public static Map instance;

    void Awake() {
        instance = this;
        stationaryWalls = new List<GameObject>();
        movingWalls = new List<GameObject>();
    }

    void Start()
    {
        void spawnStationaryWall(Vector2 position) {
            GameObject temp = Instantiate(wall);
            temp.transform.position = position;  
            stationaryWalls.Add(temp);
        }

        void spawnRow(int level) {
            for (int i = -size.x/2; i <= size.x/2; i++) {
                spawnStationaryWall(new Vector2(i, level));
            }
        }

        void spawnColumn(int level) {
            for (int i = -size.y/2; i <= size.y/2; i++) {
                spawnStationaryWall(new Vector2(level, i));
            }
        }

        spawnRow(-size.y/2);
        spawnRow(size.y/2);
        
        spawnColumn(-size.x/2);
        spawnColumn(size.x/2);
     
        for (int i = 0; i < startingWalls; i ++) {
            spawnRandomWall();       
        }
    }


    public void spawnRandomWall() {
        GameObject wall = Instantiate(this.wall);
        wall.transform.position = validPosition();  
        movingWalls.Add(wall);
    }

    Vector3 validPosition() {
        Vector3 position = new Vector3(0, 0, 0);
        do {
            position.x = Random.Range(-size.x/2 + 1, size.x/2 - 1);
            position.y = Random.Range(-size.y/2 + 1, size.y/2 - 1);
        } while (!validate(position));

        bool validate(Vector3 vector) {
            if (Snake.instance.touches(vector)) {
                return false;
            } 
            if (Snake.instance.closeToHead(vector, 3)) {
                return false;
            } 
            if (Food.instance.touches(vector)) {
                return false;
            } 
            return true;
        }

        return position;
    }
    
    public bool touchesWall(Vector3 point) {
        foreach (GameObject wall in movingWalls) {
            if (wall.transform.position == point) {
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        if (!Snake.instance.isMoving) {
            return;
        }

        time += Time.deltaTime;

        // if (Score.instance.score_ > movingWalls.Count) {
        //     spawnRandomWall();
        // }

        if(time >= delay - 0.5) {
            Color purple = new Color(0.3f, 0.3f, 0.3f);// new Color(0.7f, 0, 0.3f, 0.5f);
            foreach(GameObject wall in movingWalls) {
                SpriteRenderer sr = wall.GetComponent<SpriteRenderer>();
                sr.color = purple;
            }  
        }
        if(time >= delay) {
            time = 0;

            foreach(GameObject go in movingWalls) {
                go.transform.position = validPosition();
                SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
                sr.color = Color.black;
            }  
        }
        
    }
}
