using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public static ParticleManager instance;
    
    [SerializeField]
    public List<Transform> particles = new List<Transform>();

    private bool isParticling = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Destroy(this);
        }
    }

    void Start() {
        //setParticles(); // This line crashes menu
    }

    public void setParticling(bool active) {
        if (active == isParticling) {
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
            ps.enabled = isParticling;
            ParticleSystem.MainModule ma = tr.GetComponent<ParticleSystem>().main;
            try {
                ma.startColor = Ass.instance.storedType.GetColor() * 1.2f;
            } catch {
                Debug.Log("Ass nullptr expcetion");
            }
        }
    }
}
