using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public bool done = false;
    public bool firstCheck = true;
    public bool secondCheck = false;

[SerializeField] public float fadeOutDelay = 0f;
[SerializeField] public float fadeOutDuration = 2f;

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

    public void hideDelayed() {
        StartCoroutine(DelayedFadeOut(fadeOutDelay));
    }

    private IEnumerator DelayedFadeOut(float delay) {
        yield return new WaitForSeconds(delay);
        StartCoroutine(FadeOut(fadeOutDuration));
    }

    private IEnumerator FadeOut(float duration)
    {
        Image image = GetComponent<Image>();
        Color originalColor = image.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0);

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            image.color = Color.Lerp(originalColor, targetColor, t);
            yield return null;
        }

        image.color = targetColor;
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

    public void popup() {
        StartCoroutine(showForSeconds(1));
    }

    protected IEnumerator showForSeconds(float seconds) {
        show();
        yield return new WaitForSeconds(seconds);
        hide();
    }
}
