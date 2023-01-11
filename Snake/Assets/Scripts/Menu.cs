using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void Start()
    {
    }

    public void Play()
    {
         StartCoroutine(LoadScene("LevelSelection"));
    }

    public void Cutscene()
    {
        StartCoroutine(LoadScene("Cutscene"));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        if (Head.instance != null)
        {
            StartCoroutine(Head.instance.Death(true));
        }
        StartCoroutine(LoadScene("MainMenu"));
    }

    IEnumerator LoadScene(string levelName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
