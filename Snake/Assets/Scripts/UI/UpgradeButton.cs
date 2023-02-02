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
        costText.text = upgradeCost.ToString();
    }

    public void buyUpgrade()
    {
        Debug.Log("BUYING: " + upgradeName.ToString());
    }
}
