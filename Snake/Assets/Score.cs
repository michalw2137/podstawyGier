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

        scoreText.text = score_.ToString();
        highscoreText.text = $"high score: {highscore_}";
    }

    public void addPoints(int number) {
        score_ += number;
        scoreText.text = score_.ToString();
        if (score_ > highscore_) {
            PlayerPrefs.SetInt("highscore", score_);
        }

    }
   
}
