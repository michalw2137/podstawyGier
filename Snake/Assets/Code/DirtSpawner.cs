using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtSpawner : MonoBehaviour
{
    [SerializeField] public Vector2 start;
    [SerializeField] public Vector2 end;
    [SerializeField] public float dirtSize = 0.1f;
    [SerializeField] public float gap = 10;

    public GameObject dirtParticle;

    List<GameObject> soil;

    public static DirtSpawner instance;

    void Awake() {
        instance = this;
    }

    void Start()
    {
        soil = new List<GameObject>();

        Debug.Log("START \n");

        for(float y = start.y; y <= end.y; y += gap) 
        {
            for(float x = start.x; x <= end.x; x += gap) 
            {
                GameObject temp = Instantiate(dirtParticle);
                temp.transform.parent = transform;
                temp.transform.position = new Vector3(x, y, 0);  
                temp.transform.localScale = new Vector3(dirtSize, dirtSize, 0);

                soil.Add(temp);
            }
        }

        
    }

    void Update()
    {
        
    }
}
