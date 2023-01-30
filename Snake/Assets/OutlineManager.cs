using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutlineManager : MonoBehaviour
{
    public GameObject outline;
    public float gap = 100;
    public float startX, startY, size;

    public Sprite normalOutline;
    public Sprite normalDone;

    public Sprite dryOutline;
    public Sprite dryDone;

    public Sprite wetOutline;
    public Sprite wetDone;

    public static OutlineManager instance;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        generateOutlines();
    }

    private void generateOutlines() {
        Debug.Log(FoodManager.instance.transform.childCount);
        for(int i=0; i<FoodManager.instance.transform.childCount; i++) {
            GameObject temp = Instantiate(outline);
            //temp.transform.position = transform.position + new Vector3(i*gap, 0,0);  
            temp.transform.SetParent(transform, true);

            RectTransform rt = temp.GetComponent<RectTransform>();
            rt.anchoredPosition= new Vector3(startX + i*gap, startY, 0); 
            rt.sizeDelta = new Vector2(size, size);

            Outline o = temp.GetComponent<Outline>();
            o.foodId = i;

            FoodManager fm = FoodManager.instance;
            Food f = fm.getFood(i);
            DirtDetector dd = f.getDirtDetector();

            o.type = dd.getType();

            updateSpriteNormal(o);
        }
    }

    public void updateSpriteNormal(Outline o) {
        if(o.type == Types.normal) {
            o.GetComponent<Image>().sprite = normalOutline;
        } else
        if(o.type == Types.dry) {
            o.GetComponent<Image>().sprite = dryOutline;
        } else
        if(o.type == Types.wet) {
            o.GetComponent<Image>().sprite = wetOutline;
        } else {
            Debug.Log("incorrect type");
        }
    }

    public void updateSpriteDone(Outline o) {
        if(o.type == Types.normal) {
            o.GetComponent<Image>().sprite = normalDone;
        } else
        if(o.type == Types.dry) {
            o.GetComponent<Image>().sprite = dryDone;
        } else
        if(o.type == Types.wet) {
            o.GetComponent<Image>().sprite = wetDone;
        } else {
            Debug.Log("incorrect type");
        }
    }

    public void updateOutline(int id) {
        Outline o = transform.GetChild(id).GetComponent<Outline>();
        updateSpriteDone(o);
    }

}
