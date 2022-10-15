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
        spawn();
    }

    void spawn() {
        Vector3 position = new Vector3(0, 0, 0);
        do {
            position.x = Random.Range(-Map.instance.size.x/2 + 1, Map.instance.size.x/2 - 1);
            position.y = Random.Range(-Map.instance.size.y/2 + 1, Map.instance.size.y/2 - 1);
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
        }
    }


}
