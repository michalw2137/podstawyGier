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
    public float detectionRadius = 100.0f;

    [SerializeField]
    public float clearingRadius = 150.0f;

    [SerializeField] public Types dirtType;
    public Types type;

    private List<DirtParticle> nearbyDirtParticles;

    private Food food;

    void Awake()
    {
                type = dirtType;

    }

    public Types getType() {
        // if(type == null) {
        //     Debug.Log("HUUUUJ");
        // }
        return type;
    }

    // Start is called before the first frame update
    void Start()
    {
        food = transform.parent.GetComponent<Food>();

        nearbyDirtParticles = new List<DirtParticle>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addParticle(DirtParticle particle)
    {
        if(particle.type != type) {
            //Debug.Log("inorrect dirt type");
            return;
        }
        //Debug.Log("adding particle");
        if(isInside(particle.transform.position, clearingRadius)) 
        {
            nearbyDirtParticles.Add(particle);

            if(isInside(particle.transform.position, detectionRadius))
            {
                changeNearbyDirt(1);
                food.emitParticles(true, 2);
                food.squashIncrease();
            }
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

    public void changeNearbyDirt(int delta)
    {
        nearbyDirt += delta;
        //Debug.Log($"particle is inside {this}, changing dirt count to {nearbyDirt}");

        if(nearbyDirt >= dirtRequired) 
        {
            food.setSprite(4);
            food.setRipe(true);
            //reset();
        } else if (nearbyDirt >= dirtRequired * 3 / 4.0f) 
        {
            food.setSprite(3);
        } else if (nearbyDirt >= dirtRequired * 2 / 4.0f) 
        {
            food.setSprite(2);
        } else if (nearbyDirt >= dirtRequired * 1 / 4.0f) 
        {
            food.setSprite(1);
        }  else 
        {
            food.setSprite(0);
        }


    }
   

    
    // private void adjustColor()
    // {
    //     float finalCoeff = ripeness / maxRipeness;
    //     float startCoeff = 1 - finalCoeff;

    //     // Debug.Log($"start coeff: {startCoeff}");
    //     // Debug.Log($"final coeff: {finalCoeff}");

    //     Color startTemp = startCoeff * this.unripeColor;
    //     Color finalTemp = finalCoeff * this.ripeColor;

    //     // Debug.Log($"start Color: {startTemp}");
    //     // Debug.Log($"final Color: {finalCoeff}");

    //     this.currentColor = startTemp + finalTemp;
    // }


}
