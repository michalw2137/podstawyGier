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

    void Start()
    {
        levelText.text = level.ToString();
    }

    public void StartCutscene()
    {
        StartCoroutine(LoadScene("Cutscene2"));
    }

    public void OpenScene()
    {
        StartCoroutine(LoadScene("Level" + level.ToString()));
    }

    IEnumerator LoadScene(string levelName)
    {
        //transition.SetTrigger("Start");
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(levelName);
    }
}
