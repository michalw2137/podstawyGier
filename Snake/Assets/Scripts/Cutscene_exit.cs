using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Cutscene_exit : MonoBehaviour
{
    public static Cutscene_exit instance;

    [SerializeField] float duration = 20.0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InvokeRepeating("Exit", duration, 0);
    }

    void Update()
    {
        // Skip cutscene
        if (Input.GetButtonDown("Cancel"))
        {
            Exit();
        }
    }

    private void Exit()
    {
        SoundtrackController.instance.setPlaying(false);
        Awake();
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

}