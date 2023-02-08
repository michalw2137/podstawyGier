using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Vector3 SpawnLocation = new Vector3(-490.0f, 0.0f, 0.0f);
    public int RequiredLength = 11;
    private bool open = false;
    public Animator transition;
    public float transitionTime = 1f;
    public static Exit instance;

    public GameObject LevelCompleteUI;

    void Awake() 
    {
        instance = this;
    }

    void Start() 
    {
        int wormLength = 0;

        wormLength = WormManager.instance.StartLength;
        RequiredLength = wormLength + FoodManager.instance.gameObject.transform.childCount;
        // Debug.Log("head length = " + Head.instance.length);
        // Debug.Log("child count = " + FoodManager.instance.gameObject.transform.childCount);

    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) 
        {
            Head.instance.length = RequiredLength;
            StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "head" && isOpen())
        {
            LevelCompleteMenu.instance.UpdateScore();
            LevelCompleteMenu.instance.Pause();
            LevelCompleteUI.SetActive(true);
        }
    }

    public bool isOpen() 
    {
        if (Head.instance == null) 
        {
            return false;
        }

        if (open) 
        {            
            return true;
        }
        return Head.instance.length >= RequiredLength;
    }

    public void Open() 
    {
        open = true;
    }

    IEnumerator LoadScene(int Index)
    {
        transition.SetTrigger("Start");
        Head.instance.isMoving = false;
        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(Index);
        Head.instance.isMoving = true;
        // Set start position in new level
        Head.instance.transform.position = SpawnLocation;
        LevelProgress.instance.updateText();

    }

}
