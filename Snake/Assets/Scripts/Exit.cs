using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private int RequiredLength = 0;
    private bool open;
    public float transitionTime = 1f;

    public static Exit instance;

    void Awake() {
        instance = this;
        open = false;
    }

    void Start() {
        RequiredLength = Head.instance.startLength + FoodManager.instance.gameObject.transform.childCount;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.KeypadMinus)) {
            Head.instance.length = RequiredLength;
            StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "head" && isOpen())
        {
            Debug.Log("head touched open exit");
            int nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
            GameObject.Find("Fade").GetComponent<Animator>().Play("Transition");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public bool isOpen() {
        if (open) {            
            return true;
        }
        return Head.instance.length >= RequiredLength;
    }

    public void Open() {
        open = true;
    }

    IEnumerator LoadScene(int Index)
    {
        //Head.instance.isMoving = false;
        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(Index);
    }

}
