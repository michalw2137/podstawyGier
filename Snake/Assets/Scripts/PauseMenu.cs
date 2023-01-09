using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;

    public GameObject PauseUI;

    public static PauseMenu instance;

    public GameObject FirstSelectedButton;

    private int StartLength;
    private Vector3 StartPosition;
    private Quaternion StartRotation;

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
        if (Input.GetButtonDown("Cancel"))
        {
            // GamePad support
            EventSystem.current.SetSelectedGameObject(FirstSelectedButton);
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

    void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        IsGamePaused = false;
    }

    public void Pause()
    {
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
