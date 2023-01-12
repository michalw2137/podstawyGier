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
        if(instance == null) {
            instance = this;
        }

        GameObject [] lvlCpltObj =  GameObject.FindGameObjectsWithTag("levelComplete");
        if(lvlCpltObj.Length >2 ) 
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Update() {
        if(SceneManager.GetActiveScene().name == "Level10") {
            transform.position = new Vector3(672, -74, 0);
        } else {
            transform.position = new Vector3(485, 0, 0);
        }
    }

    void Start() {
        setParticles();
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

    private void setParticles()
    {
        foreach(Transform tr in particles) {
            tr.GetComponent<ParticleSystem>().Stop();

        }
    }
    
}
