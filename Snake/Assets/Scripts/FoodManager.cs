using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField]
    public Vector2 biggerCords;

    [SerializeField]
    public Vector2 smallerCords;

    public static FoodManager instance;

    private List<Transform> spawnedFood = new List<Transform>();


    void Awake()
    {
        instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // for(int i = 0; i < transform.childCount; ++i) {
        //     spawnedFood.Add(transform.GetChild(0));
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
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
