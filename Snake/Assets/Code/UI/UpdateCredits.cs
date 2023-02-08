using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 using UnityEngine.UI;
public class UpdateCredits : MonoBehaviour
{
    public TMP_Text creditsText;

    public static UpdateCredits instance;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        updateScore();
    }
    public void updateScore()
    {
        creditsText.text = PlayerPrefs.GetInt("credits", 0).ToString();
    }
}
