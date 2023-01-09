using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public int level;
    public TMP_Text levelText;
    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {
        levelText.text = level.ToString();
    }

    public void OpenScene()
    {
        StartCoroutine(LoadScene("Level" + level.ToString()));
    }

    IEnumerator LoadScene(string levelName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
