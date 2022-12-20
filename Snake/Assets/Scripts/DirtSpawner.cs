using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirtSpawner : MonoBehaviour
{
    [SerializeField] public Vector2 start;
    [SerializeField] public Vector2 end;
    [SerializeField] public float dirtSize;

    public GameObject dirtParticle;

    List<GameObject> soil;

    public static DirtSpawner instance;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        soil = new List<GameObject>();

        Debug.Log("START");
        spawnDirt();
                
    }

    public void spawnDirt() {
        soil.Clear();
        Debug.Log("spawning dirt");


        for (float y = start.y; y <= end.y; y += dirtSize) {
            for (float x = start.x; x <= end.x; x += dirtSize) {
                GameObject temp = Instantiate(dirtParticle);

                temp.transform.position = new Vector3(x, y, 0);  
                //temp.transform.localScale = new Vector3(dirtSize, dirtSize, 0);

                soil.Add(temp);
            }
        }
    }


}
