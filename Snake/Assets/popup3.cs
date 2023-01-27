using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup3 : MonoBehaviour
{
    public static popup3 instance;
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
        if(popup2.instance.done && firstTime) {
            StartCoroutine(waiter(2));
            GetComponent<Image>().color = new Color32(255,255,255,255);
            firstTime = false;
            Head.instance.isMoving = false;
        }

        if(popup2.instance.done && Input.GetAxis("Fire1") > 0.5) {
            Debug.Log("fire 2");
            Head.instance.isMoving = true;
        }

        if(!firstTime && !done) {
            if(FoodManager.instance.gameObject.transform.GetChild(0).GetChild(0).GetComponent<DirtDetector>().nearbyDirt > 0) {
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
