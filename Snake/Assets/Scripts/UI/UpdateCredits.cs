using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 using UnityEngine.UI;
public class UpdateCredits : MonoBehaviour
{
    public TMP_Text creditsText;

    // Update is called once per frame
    void Update()
    {
        creditsText.text = "Seeds: " + PlayerPrefs.GetInt("credits", 0).ToString();
    }
}
