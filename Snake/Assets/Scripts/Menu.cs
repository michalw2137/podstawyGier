using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

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
        StartCoroutine(LoadScene("MainMenu"));
    }

    IEnumerator LoadScene(string levelName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
