using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] 
    public AnimationCurve curve;
    public float duration = 1.0f;
    public float strengthMultiplier = 10.0f;

    public static Shake instance;

    private bool isShaking = false;

    void Awake() {
        instance = this;
    }

    public void startShake() {
        if(isShaking) {
            return;
        }
        isShaking = true;
        StartCoroutine(Shaking());
    }

    IEnumerator Shaking() {
        Vector3 startingPosition = transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < duration) {
            elapsedTime += Time.deltaTime;

            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startingPosition + Random.insideUnitSphere * strength * strengthMultiplier;

            yield return null;
        }
        isShaking = false;
        transform.position = startingPosition;
    }    
}
