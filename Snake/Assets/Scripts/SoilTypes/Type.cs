using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status {eatable, eaten, fertilizer};
public enum Types {normal, wet, dry};

public class Type : MonoBehaviour
{
    [SerializeField] public Color defaultColor; 

    [SerializeField] public Color deletedColor;

    [SerializeField] public Color respawnedColor; 

    [SerializeField] public Sprite defaultSprite;
    [SerializeField] public Sprite respawnedSprite;

    
    [SerializeField]
    public Types type;

    public Color GetColor(Status status) {
       switch(status){
            case Status.eatable:  
                return defaultColor;

            case Status.eaten: 
                return deletedColor;

            case Status.fertilizer: 
                return respawnedColor;

            default: return new Color(255, 0, 0, 255);
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
