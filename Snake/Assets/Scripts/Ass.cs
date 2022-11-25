using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ass : MonoBehaviour
{
    public static Ass instance;

    public int dirtCount {get; set;}

    [SerializeField]
    public int dirtCapMultiplier = 100;

    private int dirtCap;

    public Type storedType {get; set;}

    void Awake() {
        instance = this;
        dirtCount = 0;
        storedType = TypeNormal.instance;
    }

    public void respawnParticle(DirtParticle dp) {
        if (dp.status != Status.eaten) {
            return;
        }
        if(dirtCount <= 0) {
            return;
        }
        
        dirtCount --;
        Score.instance.updateText();

        dp.setType(this.storedType);
        dp.setStatus(Status.fertilizer);

        FoodManager.instance.addParticle(dp);      
    }

    public void eatParticle(DirtParticle dp) {
        if (dp.status != Status.eatable) {
            ParticleManager.instance.setParticling(false);
            return;
        }

        dp.setStatus(Status.eaten);

        if (dirtCount == 0) {
            this.storedType = dp.type;
        }
        if (dp.type != storedType) {
            ParticleManager.instance.setParticling(false);
            return;
        }
        if (dirtCount >= dirtCap) {
            ParticleManager.instance.setParticling(false);
            return;
        } 

        if(Input.GetAxis("Fire2") == 1) {
            dirtCount ++;
            Score.instance.updateText(); 
            ParticleManager.instance.setParticling(true);
        } 
    }

    public void setTransform(Transform transform) 
    {
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;
    }


    public void updateCap(int size)
    {
        dirtCap = dirtCapMultiplier * size;
        //Debug.Log($"current cup = {dirtCap}");
    }

    public int getMaxCapacity()
    {
        return dirtCap;
    }

}
