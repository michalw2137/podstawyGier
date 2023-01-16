using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
         //StartCoroutine(LoadScene("LevelSelection"));
         SceneManager.LoadScene("LevelSelection");
    }

    public void Cutscene()
    {
        //StartCoroutine(LoadScene("Cutscene"));
        SceneManager.LoadScene("Cutscene");

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        //StartCoroutine(LoadScene("MainMenu"));
        SceneManager.LoadScene("MainMenu");

    }

    IEnumerator Wait1sec(string levelName)
    {
        // transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        // SceneManager.LoadScene(levelName);
    }
}
