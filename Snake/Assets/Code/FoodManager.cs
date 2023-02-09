using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField] public Vector2 biggerCords;

    [SerializeField] public Vector2 smallerCords;

    public static FoodManager instance;

    void Awake()
    {
        instance = this; 

        for(int i=0; i<transform.childCount; i++) {
            getFood(i).id = i;
        }
    }

    public Food getFood(int id=0) {
        if(id >= transform.childCount) {
            Debug.LogError($"id={id} too big for child count={transform.childCount}");
            return null;
        }
        return transform.GetChild(id).GetComponent<Food>();
    }

    public bool levelCompleted() {
        for(int i=0; i<transform.childCount; i++) {
            if(!getFood(i).hasGrown()) {
                return false;
            }
        }
        return true;
    }

    // public void addParticle(DirtParticle particle) 
    // {
    //     foreach(Transform food in spawnedFood)
    //     {
    //         food.GetChild(0).GetComponent<DirtDetector>().addParticle(particle);
    //         Debug.Log("adding particle to {food}");
    //     }
    // }
}
