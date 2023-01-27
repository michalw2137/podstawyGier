using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup1 : MonoBehaviour
{
    public static popup1 instance;
    public bool done = false;
    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter(0.1f));
        GetComponent<Image>().color = new Color32(255,255,255,255);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0) {
            GetComponent<Image>().color = new Color32(255,255,255,0);
            done = true;
            Head.instance.isMoving = true;
        }
    }

    IEnumerator waiter(float seconds) {
        //Wait for 4 seconds
        yield return new WaitForSeconds(seconds);
        Head.instance.isMoving = false;

    }
}
