using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public bool done = false;
    public bool firstCheck = true;
    public bool secondCheck = false;

    protected IEnumerator stopHeadAfterSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
        show();
        Head.instance.isMoving = false;
        firstCheck = false;
        secondCheck = true;
    }

    protected IEnumerator moveHeadAfterSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
        Head.instance.isMoving = true;
    }

    public void hide() {
        GetComponent<Image>().color = new Color32(255,255,255,0);
    }

    public void show() {
        GetComponent<Image>().color = new Color32(255,255,255,255);
    }

    protected bool anyInput() {
        if(Input.GetAxis("Horizontal") != 0) {
            return true;
        }
        if(Input.GetAxis("Fire1") != 0) {
            return true;
        };
        if(Input.GetAxis("Fire2") != 0) {
            return true;
        };
        return false;
    }
}
