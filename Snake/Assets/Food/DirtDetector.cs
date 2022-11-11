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
            //ripeness += Time.deltaTime;
            ripeness = maxRipeness;
            //adjustColor();

            Food.instance.setColor(currentColor);

        }

        if(ripeness >= maxRipeness)
        {
            foreach(DirtParticle particle in nearbyDirtParticles)
            {
                particle.resetColor();
            }
            nearbyDirtParticles.Clear();
        }
    }

    public bool isRipe()
    {
        return (ripeness >= maxRipeness);
    }

    public void changeNearbyDirt(int delta)
    {
        nearbyDirt += delta;

        if(nearbyDirt >= dirtRequired * 3 / 3.0f) {
            Food.instance.setSprite(3);
        } else if (nearbyDirt >= dirtRequired * 2 / 3.0f) {
            Food.instance.setSprite(2);
        } else if (nearbyDirt >= dirtRequired * 1 / 3.0f) {
            Food.instance.setSprite(1);
        }  else {
            Food.instance.setSprite(0);
        }
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
                changeNearbyDirt(1);
            }
        }
    }

    private void adjustColor()
    {
        float finalCoeff = ripeness / maxRipeness;
        float startCoeff = 1 - finalCoeff;

        // Debug.Log($"start coeff: {startCoeff}");
        // Debug.Log($"final coeff: {finalCoeff}");

        Color startTemp = startCoeff * this.unripeColor;
        Color finalTemp = finalCoeff * this.ripeColor;

        // Debug.Log($"start Color: {startTemp}");
        // Debug.Log($"final Color: {finalCoeff}");

        this.currentColor = startTemp + finalTemp;

    }
    public void reset()
    {
        nearbyDirt = 0;
        ripeness = 0;

        
    }
}
