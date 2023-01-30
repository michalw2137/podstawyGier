using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBarManager : MonoBehaviour
{
    private Slider slider;

    [SerializeField]
    public float fillSpeed = 1.5f;

    private float targetProgress = 0;
    
    private void Awake() {
        slider = gameObject.GetComponent<Slider>();
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
    }

    public void UpdateDirtSlider() {
                slider.gameObject.transform.Find("Background").GetComponent<Image>().color = Type.getInstance(Ass.instance.storedType).GetColor(Status.fertilizer);

        slider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color =  Type.getInstance(Ass.instance.storedType).GetColor();
        targetProgress = (Ass.instance.dirtCount / (float)Ass.instance.getMaxCapacity());
    }
}
