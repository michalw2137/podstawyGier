using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBarManager : MonoBehaviour
{
    private Slider slider;
    private RectTransform sliderRect;

    [SerializeField]
    private float currentLenght = 0;

    private float increaseSpeed = 3f;

    private float targetProgress = 0;

    private float targetLenght = 0;
    
    private void Awake() {
        slider = gameObject.GetComponent<Slider>();
        sliderRect = slider.GetComponent<RectTransform>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirtSlider();
        if(slider.value != targetProgress) 
        {
            slider.value = targetProgress;
        }
        if(currentLenght < targetLenght)
        {
            currentLenght += increaseSpeed;
            sliderRect.sizeDelta = new Vector2(currentLenght, sliderRect.sizeDelta.y);
        }
        

    }

    public void UpdateDirtSlider() {
        slider.gameObject.transform.Find("Background").GetComponent<Image>().color = Type.getInstance(Ass.instance.storedType).GetColor(Status.fertilizer);
        
        slider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color =  Type.getInstance(Ass.instance.storedType).GetColor();
        float maxCap = (float)Ass.instance.getMaxCapacity();
        
        targetProgress = (Ass.instance.dirtCount / maxCap);
        if(maxCap > targetLenght) 
        {
            targetLenght = maxCap;
        }
        //Debug.Log(targetLenght);
    }
}
