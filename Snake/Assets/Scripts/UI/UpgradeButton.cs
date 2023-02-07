using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 using UnityEngine.UI;
public class UpgradeButton : MonoBehaviour
{
    public string upgradeName;
    public TMP_Text nameText;
    public string upgradeDesc;
    public TMP_Text descText;
    public Sprite upgradeIcon;
    public Image iconImage; 
    public int upgradeCost;
    public TMP_Text costText;
    void Start()
    {
        nameText.text = upgradeName.ToString();
        descText.text = upgradeDesc.ToString();
        iconImage.sprite = upgradeIcon;
    }

    void Update() 
    {
        if(PlayerPrefs.GetInt(upgradeName, 0) == 1) 
        {
            costText.text = "\u221A";
        }
        else
        {
            costText.text = upgradeCost.ToString();
        }

        if(Input.GetKeyDown(KeyCode.KeypadDivide)) {
            removeUpgrade();
        }
        if(Input.GetKeyDown(KeyCode.KeypadMultiply)) {
            addCredits();
        }
    }

    public void buyUpgrade()
    {
        if(PlayerPrefs.GetInt(upgradeName, 0) == 1) 
        {
            Debug.Log("ALREADY BOUGHT");
            popup7.instance.popup();
            return;
        }
        if(upgradeCost > PlayerPrefs.GetInt("credits", 0)) 
        {
            Debug.Log("TOO LITTLE CREDTIS");
            popup8.instance.popup();
            return;
        }
        

        //Debug.Log("BUYING: " + upgradeName.ToString());
        PlayerPrefs.SetInt("credits", PlayerPrefs.GetInt("credits", 0) - upgradeCost);
        UpdateCredits.instance.updateScore();
        PlayerPrefs.SetInt(upgradeName, 1);

    }

    public void removeUpgrade()
    {
        //Debug.Log("REMOVING" + upgradeName.ToString());
        PlayerPrefs.SetInt(upgradeName, 0);
        PlayerPrefs.SetInt("credits", PlayerPrefs.GetInt("credits", 0) + upgradeCost);
        UpdateCredits.instance.updateScore();
    }

    public void addCredits()
    {
        //Debug.Log("ADDING MONEY");
        PlayerPrefs.SetInt("credits", PlayerPrefs.GetInt("credits", 0) + 5);
        UpdateCredits.instance.updateScore();
    }
}
