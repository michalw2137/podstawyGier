using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Vector3 SpawnLocation = new Vector3(-450.0f, 0.0f, 0.0f);
    public int RequiredLength = 11;
    private bool open = false;

    public static Exit instance;

    void Awake() {
        instance = this;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "head" && Predicate())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            // Set start position in new level
            Head.instance.transform.position = SpawnLocation;
        }
    }

    private bool Predicate() {
        if (open) {
            return true;
        }
        return Head.instance.length >= RequiredLength;
    }

    public void Open() {
        open = true;
    }

    public bool isOpen() {
        return Predicate();
    }

}
