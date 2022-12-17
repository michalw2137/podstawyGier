using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodParticleManager : MonoBehaviour
{
    public FoodParticleManager instance;
    
    [SerializeField]
    public List<Transform> particles = new List<Transform>();

    void Awake() {
        instance = this;
    }

    void Start() {
        setParticles();
    }

    public void setParticling(bool state, int n) 
    {
        Debug.Log($"setting {n} particle to {state}");
        if(state) {
            particles[n].GetComponent<ParticleSystem>().Play();
        }
        else 
        {
            particles[n].GetComponent<ParticleSystem>().Stop();
        }

        var ps = particles[n].GetComponent<ParticleSystem>().emission;
        if(n == 1) 
        {
            particles[n].GetComponent<ParticleSystem>().Play();
        }
        ps.enabled = state;
    }

    private void setParticles()
    {
        foreach(Transform tr in particles) {
            tr.GetComponent<ParticleSystem>().Stop();
            // var ps = tr.GetComponent<ParticleSystem>().emission;
            // ps.enabled = false;
        }
    }
}
