using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public static ParticleManager instance;
    
    [SerializeField]
    public List<Transform> particles = new List<Transform>();

    private bool isParticling = true;

    void Awake() {
        instance = this;
    }

    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void particling(bool active) {
        if (active && isParticling) {
            return;
        }
        //Debug.Log($"changing isParticling to {active}");
        isParticling = active;
        setParticles();
    }

    private void setParticles()
    {
        foreach(Transform tr in particles) {
            var ps = tr.GetComponent<ParticleSystem>().emission;
            ps.enabled = !isParticling;
        }
    }
}
