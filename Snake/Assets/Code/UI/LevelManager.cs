using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] lvlButtons;
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 4);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 4 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }
}
