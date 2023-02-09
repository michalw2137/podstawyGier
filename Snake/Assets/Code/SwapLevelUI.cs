using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapLevelUI : MonoBehaviour
{
    public static SwapLevelUI instance;

    [SerializeField] float duration = 0.0f;
    [SerializeField] string NextLevelName = "MainMenu";

    void Awake()
    {
        instance = this;
    }

    public void SwapLevel()
    {
        InvokeRepeating("Exit", duration, 0);
    }

    private void Exit()
    {
        if (SoundtrackController.instance != null)
        {
            SoundtrackController.instance.setPlaying(false);
        }
        Awake();
        SceneManager.LoadScene(NextLevelName, LoadSceneMode.Single);
    }
}