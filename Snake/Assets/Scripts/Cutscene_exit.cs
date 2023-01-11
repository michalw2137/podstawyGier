using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Cutscene_exit : MonoBehaviour
{
    public static Cutscene_exit instance;

    [SerializeField] float duration = 20.0f;
    [SerializeField] string NextLevelName = "MainMenu";

    void Awake()
    {
        instance = this;
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
        // if(Head.instance != null) {
        //     Head.instance.DestroyWorm();
        // }
        SoundtrackController.instance.setPlaying(false);
        Awake();
        SceneManager.LoadScene(NextLevelName, LoadSceneMode.Single);
    }

}