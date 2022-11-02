using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirt : MonoBehaviour
{
    [SerializeField] public Vector2 start;
    [SerializeField] public Vector2 end;
    [SerializeField] public float dirtSize;

    public GameObject dirtParticle;

    List<GameObject> soil;


    // Start is called before the first frame update
    void Start()
    {
        soil = new List<GameObject>();

        Debug.Log("START \n");

        for(float y=start.y; y<=end.y; y += dirtSize) {
            for(float x=start.x; x<=end.x; x += dirtSize) {
                GameObject temp = Instantiate(dirtParticle);
                temp.transform.position = new Vector3(x, y, 0);  
                temp.transform.localScale = new Vector3(dirtSize, dirtSize, 0);
                soil.Add(temp);
                //Debug.Log($"dirt spawned at {x} {y} \n");
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
