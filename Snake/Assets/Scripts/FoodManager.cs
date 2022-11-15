using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{

    [SerializeField]
    public List<GameObject> allFood = new List<GameObject>();

    [SerializeField]
    public Vector2 biggerCords;

    [SerializeField]
    public Vector2 smallerCords;

    public static FoodManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject food in allFood) 
        {
           // food.GetComponent<Food>().Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addParticle(DirtParticle particle) 
    {
        foreach(GameObject food in allFood)
        {
            food.transform.GetChild(0).GetComponent<DirtDetector>().addParticle(particle);
        }
    }
}
