using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


    public class Cutscene_exit : MonoBehaviour
    {
        public static Cutscene_exit instance;

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
        InvokeRepeating("Exit", 46, 0);
    }

    void Update()
    {
    }

    private void Exit()
    {
        Awake();
        SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
    }

}