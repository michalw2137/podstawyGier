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

    public SFXmanager sfx;

    private SquashManager sm;

    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Destroy(this);
        }
        sfx = GetComponent<SFXmanager>();
        dirtCount = 0;
        storedType = TypeNormal.instance;

    }

    void Start() {
        if(Head.instance.isCutscene) {
            storedType = TypeNormal.instance;
        }
    }

    public void respawnParticle(DirtParticle dp) {
        if(Head.instance.isCutscene) {
            sfx.playSoundWithoutRepeat(1);
            dp.setType(this.storedType);
            dp.setStatus(Status.fertilizer);
            for(int i = 0; i < FoodManager.instance.transform.childCount; i++) {
                FoodManager.instance.gameObject.transform.GetChild(i).GetChild(0).GetComponent<DirtDetector>().addParticle(dp);
            } 
            return;
        }

        if (dp.status != Status.eaten && dp.status != Status.deleted) {
            return;
        }
        if(dirtCount <= 0) {
            return;
        }
        if(Input.GetAxis("Fire2") == 1) {
            return;
        }
        
        dirtCount --;

        Score.instance.updateText();
        sfx.playSoundWithoutRepeat(1);
        dp.setType(this.storedType);
        dp.setStatus(Status.fertilizer);
        Shake.instance.startShake();

        for(int i = 0; i < FoodManager.instance.transform.childCount; i++) {
            FoodManager.instance.gameObject.transform.GetChild(i).GetChild(0).GetComponent<DirtDetector>().addParticle(dp);
        } 
    }

    public void eatParticle(DirtParticle dp) {
        if(Head.instance.isCutscene) {
            ParticleManager.instance.setParticling(true); 
            dp.setStatus(Status.eaten);

            return;
        }

        if (dp.status != Status.eatable) {
            ParticleManager.instance.setParticling(false);
            return;
        }

        dp.setStatus(Status.deleted);

        if (dirtCount == 0) {
            this.storedType = dp.type;
        }
        if (dp.type.type != storedType.type) {
            ParticleManager.instance.setParticling(false);
            return;
        }
        if (dirtCount >= dirtCap) {
            ParticleManager.instance.setParticling(false);
            return;
        } 

        if(Input.GetAxis("Fire2") == 1) {
            dirtCount ++;
            Debug.Log("particle eaten");
            sfx.playSoundWithoutRepeat(0);
            ParticleManager.instance.setParticling(true);
            dp.setStatus(Status.eaten);
        } else {
            ParticleManager.instance.setParticling(false);
            //dp.setStatus(Status.deleted);
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

    public bool isFull() {
        return dirtCount == dirtCap;
    }
}
