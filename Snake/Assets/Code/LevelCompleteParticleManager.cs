using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteParticleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelCompleteParticleManager instance;

    [SerializeField]
    public List<Transform> particles = new List<Transform>();

    void Awake() {
        instance = this;
        stopParticles();
    }

    void Start() {
        stopParticles();
    }

    public void setParticling(bool state) 
    {
        //Debug.Log($"setting particle to {state}");
        if(state) {
            particles[0].gameObject.GetComponent<Renderer>().sortingOrder = 60;
            particles[0].GetComponent<ParticleSystem>().Play();
        }
        else 
        {
            particles[0].gameObject.GetComponent<Renderer>().sortingOrder = 0;
            particles[0].GetComponent<ParticleSystem>().Stop();
        }
    }

    private void stopParticles()
    {
        foreach(Transform tr in particles) {
            tr.gameObject.GetComponent<Renderer>().sortingOrder = 0;
            tr.GetComponent<ParticleSystem>().Stop();
        }
    }
    
}
