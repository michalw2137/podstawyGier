using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status {eatable, eaten, fertilizer, nonDirt};
public enum Types {normal, wet, dry};

public class Type : MonoBehaviour
{
    [SerializeField] public Color wormColor; 

    [SerializeField] public Sprite defaultSprite;
    [SerializeField] public Color defaultColor; 

    [SerializeField] public Color deletedColor; 

    [SerializeField] public Sprite respawnedSprite;
    [SerializeField] public Color respawnedColor; 

    [SerializeField] public Types type;

    private static Color neutralColor = new Color(1, 1, 1, 1);
    //private static Color deletedColor = new Color(0,0,0,0);

    public Color GetColor(Status status = Status.nonDirt) {
        switch(status){
            case Status.nonDirt:  
                return wormColor;

            case Status.eatable:
                return defaultColor;

            case Status.eaten: 
                return deletedColor;

            case Status.fertilizer: 
                return respawnedColor;

            default: 
                Debug.Log("Get Color default");
                return new Color(255, 0, 0, 255);
        } 
    }

    public Sprite GetSprite(Status status) {
       switch(status){
            case Status.eatable:  
                return defaultSprite;

            case Status.eaten: 
                return respawnedSprite;

            case Status.fertilizer: 
                return respawnedSprite;

            default: return defaultSprite;
        } 
    }

    // public static Type GetType(Status status) {
    //     Type temp = new Type();
    //     temp.SetType(status);
    //     return temp;
    // }
    
    // public void SetType(Status status) {
    //     switch(status){
    //         case Status.eatable:  
    //             SetEatable(); 
    //             break;

    //         case Status.eaten: 
    //             SetEaten(); 
    //             break;

    //         case Status.fertilizer: 
    //             SetFertilizer(); 
    //             break;

    //         default: break;
    //     }
    // }

    
    
    // public void SetEatable() {

    //     defaultColor = new Color(255, 0, 0, 1); 
    //     deletedColor =  new Color(0, 0, 0, 0); 
    //     respawnedColor = new Color(0, 0, 255, 255);
    //     typeId = 1;
    //     status = Status.eatable;

    // } 

    // public void SetEaten() {

    //     defaultColor = new Color(0, 255, 0, 1); 
    //     deletedColor =  new Color(0, 0, 0, 0); 
    //     respawnedColor = new Color(0, 0, 255, 255);
    //     typeId = 2;
    //     status = Status.eaten;

    // } 

    // public void SetFertilizer() {

    //     defaultColor = new Color(0, 255, 0, 1); 
    //     deletedColor =  new Color(0, 0, 0, 0); 
    //     respawnedColor = new Color(0, 0, 255, 255);
    //     typeId = 3;
    //     status = Status.fertilizer;

    // } 
}
