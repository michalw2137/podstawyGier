using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static Food instance;

    void Awake() {
        instance = this;
    }

    void Start() {
        //spawn();
    }

    void spawn() {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();

        Vector3 position = new Vector3(0, 0, 0);
        int step = Snake.instance.Step;
        int width = Map.instance.size.x / 2;
        int height = Map.instance.size.y / 2;
        do {
            position.x = Random.Range(-width/step + 1, width/step - 1) * step;
            position.y = Random.Range(-height/step + 1, height/step - 1) * step;
            //Debug.Log($"validating food at {position}");

        } while (!validate(position));
        
        bool validate(Vector3 vector) {
            if (Snake.instance.touches(vector)) {
                return false;
            } else if (Map.instance.touchesWall(vector)) {
                return false;
            } else {
                return true;
            }
        }

        this.transform.position = position;
        //Debug.Log($"spawned food at {position}");
    }

    public bool touches(Vector3 position) {
        if (position == this.transform.position) {
            return true;
        } else {
            return false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "head") {
            spawn();
        } else if (other.tag == "body") {
            spawn();
        } else if (other.tag == "obstacle") {
            spawn();   
        } else if (other.tag == "map") {
            spawn();   
        }
    }


}
