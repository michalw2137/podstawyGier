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
    }

    public void buyUpgrade()
    {
        if(PlayerPrefs.GetInt(upgradeName, 0) == 1) 
        {
            Debug.Log("ALREADY BOUGHT");
            return;
        }
        if(upgradeCost > PlayerPrefs.GetInt("credits", 0)) 
        {
            Debug.Log("TOO LITTLE CREDTIS");
            return;
        }
        

        Debug.Log("BUYING: " + upgradeName.ToString());
        PlayerPrefs.SetInt("credits", PlayerPrefs.GetInt("credits", 0) - upgradeCost);
        PlayerPrefs.SetInt(upgradeName, 1);

    }
}
