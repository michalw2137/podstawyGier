using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveDetection : MonoBehaviour
{
    private ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        part = this.GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("RADIOACTIVE COLLIDES WITH STH");
        if (other.tag == "body")
        {
            Debug.Log("KURWAMAC");      
        }
        if (other.tag == "head")
        {
            Debug.Log("KURWAMAC2");      
        }
        if (other.tag == "dirt")
        {
            Debug.Log("co za gowno");      
        }
        // int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        // Rigidbody rb = other.GetComponent<Rigidbody>();
        // int i = 0;

        // while (i < numCollisionEvents)
        // {
        //     if (rb)
        //     {
        //         Vector3 pos = collisionEvents[i].intersection;
        //         Vector3 force = collisionEvents[i].velocity * 10;
        //         rb.AddForce(force);
        //     }
        //     i++;
        // }
    }

}