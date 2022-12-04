using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Vector3 SpawnLocation = new Vector3(-450.0f, 0.0f, 0.0f);
    public int RequiredLength = 11;
    private Head player;
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
        if (player is null)
        {
            player = Head.instance;
        }

        if (other.tag == "head" && player.length >= RequiredLength)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            // Set start position in new level
            player.transform.position = SpawnLocation;
        }
    }
}
