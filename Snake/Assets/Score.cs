using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    public int score_ = 0;
    private int highscore_ = 0;

    public static Score instance;

    void Awake() {
        instance = this;
    }

    void Start()
    {
        highscore_ = PlayerPrefs.GetInt("highscore", 0);

        scoreText.text = $"dirt stored: {eatingDirt.instance.dirtCount}";
        highscoreText.text = $"high score: {highscore_}";
    }

    public void updateText() {
        scoreText.text = $"dirt stored: {eatingDirt.instance.dirtCount}";

    }
   
}
