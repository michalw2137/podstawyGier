using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtDetector : MonoBehaviour
{
    [SerializeField]
    public int nearbyDirt = 0;

    [SerializeField]
    public int dirtRequired = 150;

    [SerializeField]
    public float maxRipeness = 5.0f;

    [SerializeField]
    public float detectionRadius = 100.0f;

    [SerializeField]
    public float clearingRadius = 150.0f;

    [SerializeField]
    public Color unripeColor = new Color(85, 255, 0, 255);


    [SerializeField]
    public Color ripeColor = new Color(255, 255, 0, 255);

    [SerializeField]
    public Color currentColor;

    public static float ripeness = 0.0f;

    public static DirtDetector instance;

    private List<DirtParticle> nearbyDirtParticles;


    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentColor = unripeColor;
        Food.instance.setColor(currentColor);

        nearbyDirtParticles = new List<DirtParticle>();
    }

    // Update is called once per frame
    void Update()
    {

        // if(nearbyDirt>0)
        //     Debug.Log($"nearby dirt: {nearbyDirt}");

        if(nearbyDirt >= dirtRequired && ripeness < maxRipeness) {
            ripeness += Time.deltaTime;

            currentColor.r = ripeness / maxRipeness;
            currentColor.g += ripeness / maxRipeness / 16.0f;
            //Debug.Log(currentColor.b);

            Food.instance.setColor(currentColor);

            Debug.Log($"ripeness: {ripeness}");
        }

        if(ripeness >= maxRipeness)
        {
            currentColor.g = 1;
            Food.instance.setColor(currentColor);

            foreach(DirtParticle particle in nearbyDirtParticles)
            {
                particle.resetColor();
            }
            nearbyDirtParticles.Clear();
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "respawnedDirt") {
            nearbyDirt++;
            Debug.Log($"nearbyDirt: {nearbyDirt}");
        }
    }

    public bool isRipe()
    {
        return (ripeness>maxRipeness);
    }

    public void changeNearbyDirt(int delta)
    {
        nearbyDirt += delta;
    }

    public bool isInside(Vector3 coords, float radius)
    {
        if(coords.x <= transform.position.x + radius && coords.x >= transform.position.x - radius)
        {
            if(coords.y <= transform.position.y + radius && coords.y >= transform.position.y - radius)
            {
                return true;                    
            } else
            {
                return false;
            }
        } else{
            return false;
        }
        //return Mathf.Pow(coords.x - transform.position.x, 2) + Mathf.Pow(coords.y - transform.position.y, 2) <= Mathf.Pow(radius, 2);
    }

    public void addParticle(DirtParticle particle)
    {
        if(isInside(particle.transform.position, clearingRadius)) 
        {
            nearbyDirtParticles.Add(particle);

            if(isInside(particle.transform.position, detectionRadius))
            {
                nearbyDirt ++;
            }
        }
    }

    public void reset()
    {
        nearbyDirt = 0;
        ripeness = 0;

        
    }
}
