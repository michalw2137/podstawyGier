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
         StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadScene(int Index)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(Index);
    }
}
