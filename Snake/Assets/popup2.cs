using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup2 : MonoBehaviour
{
    public static popup2 instance;
    public bool done = false;
    private bool firstTime = true;
    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = new Color32(255,255,255,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(popup1.instance.done && firstTime) {
            StartCoroutine(waiter(2));
            GetComponent<Image>().color = new Color32(255,255,255,255);
            firstTime = false;
        }

        if(!firstTime && !done) {
            if(Ass.instance.isFull()) {
                GetComponent<Image>().color = new Color32(255,255,255,0);

                done = true;
            }
        }
    }

    IEnumerator waiter(float seconds) {
        //Wait for 4 seconds
        yield return new WaitForSeconds(seconds);
    }
}
