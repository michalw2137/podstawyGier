using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{

    [SerializeField]
    public GameObject food;

    [SerializeField]
    int foodCount;

    private List<GameObject> allFood = new List<GameObject>(5);

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
        for(int i = 0; i < foodCount; ++i) {
            allFood.Add(Instantiate(food));
            allFood[i].GetComponent<Food>().Spawn();
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
