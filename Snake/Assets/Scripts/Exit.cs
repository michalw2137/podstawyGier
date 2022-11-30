using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "head")
        {
            Head player = Head.instance;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            // Set start position in new level
            player.transform.position = new Vector3(-450.0f, 0.0f, 0.0f);
        }
    }
}
