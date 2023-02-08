using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;

    public GameObject PauseUI;

    public static PauseMenu instance;

    public GameObject FirstSelectedButton;

    public GameObject ResumeButton;

    private int StartLength;
    private Vector3 StartPosition;
    private Quaternion StartRotation;

    public Image GameOver;
    public Image GamePaused;

    private void Start()
    {
        instance = this;
        if (Head.instance != null)
        {
            StartLength = Head.instance.length < Head.instance.startLength ? Head.instance.startLength : Head.instance.length;
            StartPosition = Head.instance.transform.position;
            StartRotation = Head.instance.transform.rotation;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !Head.instance.isDestroyed)
        {
            if (IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        IsGamePaused = false;
    }

    Color ChangeAlpha(Color ImageColor, float Alpha)
    {
        ImageColor.a = Alpha;
        return ImageColor;
    }

    public void Pause()
    {
        if (!Head.instance.isDestroyed) // GamePaused
        {
            GamePaused.color = ChangeAlpha(GamePaused.color, 1.0f);
            GameOver.color = ChangeAlpha(GameOver.color, 0.0f);
            ResumeButton.SetActive(true);
            EventSystem.current.SetSelectedGameObject(ResumeButton); // GamePad support
        }
        else // GameOver
        {
            GamePaused.color = ChangeAlpha(GamePaused.color, 0.0f);
            GameOver.color = ChangeAlpha(GameOver.color, 1.0f);
            ResumeButton.SetActive(false);
            EventSystem.current.SetSelectedGameObject(FirstSelectedButton); // GamePad support
        }
        PauseUI.SetActive(true);
        Time.timeScale = 0.0f;
        IsGamePaused = true;
    }

    public void MainMenu()
    {
        if (Head.instance != null)
        {
            StartCoroutine(Head.instance.Death(true));
        }
        SceneManager.LoadScene("MainMenu");
        Resume();
    }

    public void Restart()
    {
        if (Head.instance != null)
        {
            Head.instance.length = StartLength;
            Head.instance.transform.position = StartPosition;
            Head.instance.transform.rotation = StartRotation;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }
}
