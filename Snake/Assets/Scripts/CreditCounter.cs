using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCounter : MonoBehaviour
{
    public static CreditCounter instance;

        private int potentialCredits = 0;

    private int credtis = 0;
    
    void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update() {
        // Debug.Log($"potential = {potentialCredits}");
         //Debug.Log($"credits = {PlayerPrefs.GetInt("credits", 0)}");
    }

    public void changePotentialCredits(int delta) 
    {
        potentialCredits += delta;
    }

    public void confirmCredits()
    {
        PlayerPrefs.SetInt("credits", PlayerPrefs.GetInt("credits", 0) + potentialCredits);
        potentialCredits = 0;
    }

}
