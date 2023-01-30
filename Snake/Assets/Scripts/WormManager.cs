using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormManager : MonoBehaviour
{
    public Vector3 StartPosition = new Vector3(-490.0f, 0.0f, 0.0f);
    public Vector3 StartRotation = Vector3.zero;
    public int StartLength;
    public static WormManager instance;

    void Awake()
    {
        instance = this;
    }


    void Start()
    {
        if (Head.instance == null)
        {
            Debug.Log("Something went wrong, where head?");
            return;
        }
        Debug.Log("worm manager start");

        Head.instance.length = StartLength;
        Head.instance.transform.position = StartPosition;
        Head.instance.transform.eulerAngles = StartRotation;
    }
}
