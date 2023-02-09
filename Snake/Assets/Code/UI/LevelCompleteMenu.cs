using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{
    public static LevelCompleteMenu instance;

    public GameObject FirstSelectedButton;

    public Animator transition;
    public float transitionTime = 1f;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {

    }

    public void NextLevel()
    {
        Time.timeScale = 1.0f;
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
        Time.timeScale = 1.0f;
        if (Head.instance != null)
        {
            StartCoroutine(Head.instance.Death(true));
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void Upgrades()
    {
        Time.timeScale = 1.0f;
        if (Head.instance != null)
        {
            StartCoroutine(Head.instance.Death(true));
        }
        SceneManager.LoadScene("Upgrades");
    }


    public void Pause()
    {
        Time.timeScale = 0.0f;
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
