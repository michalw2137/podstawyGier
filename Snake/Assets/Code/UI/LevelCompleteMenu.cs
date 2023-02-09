using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{
    public static LevelCompleteMenu instance;

    public GameObject FirstSelectedButton;
    public GameObject PauseCanvas;

    [NonSerialized]
    public bool IsActive = false;

    public Animator transition;
    public float transitionTime = 1f;

    private void Start()
    {
        instance = this;
    }
    public void NextLevel()
    {
        Resume();
        int nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
        CreditCounter.instance.confirmCredits();
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void MainMenu()
    {
        Resume();
        if (Head.instance != null)
        {
            StartCoroutine(Head.instance.Death(true));
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void Upgrades()
    {
        Resume();
        if (Head.instance != null)
        {
            StartCoroutine(Head.instance.Death(true));
        }
        SceneManager.LoadScene("Upgrades");
    }


    public void Pause()
    {
        IsActive = true;
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        IsActive = false;
        Time.timeScale = 1.0f;
        PauseCanvas.SetActive(false);
    }

    IEnumerator LoadScene(int Index)
    {
        transition.SetTrigger("Start");
        Head.instance.isMoving = false;
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(Index);
        Head.instance.isMoving = true;
        LevelProgress.instance.updateText();
    }
}
