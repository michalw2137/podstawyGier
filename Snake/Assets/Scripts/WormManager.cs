using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormManager : MonoBehaviour
{
    public Vector3 StartPosition = new Vector3(-490.0f, 0.0f, 0.0f);
    public int StartLength;

    void Start()
    {
        if (Head.instance == null)
        {
            Debug.Log("Something went wrong, where head?");
            return;
        }
        Head.instance.length = StartLength;
        Head.instance.transform.position = StartPosition;
    }
}
