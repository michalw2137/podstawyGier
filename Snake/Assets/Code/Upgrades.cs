using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public static Upgrades instance;
    void Start()
    {
        Awake();
    }

    void Awake()
    {
        instance = this;
    }

    public int upgradeDirtCap()
    {
        if(PlayerPrefs.GetInt("Increase Dirt Capacity", 0) == 1)
        {
            return 13;
        }
        else{
            return 9;
        }
    }

    public float applyBoost()
    {
        if(PlayerPrefs.GetInt("Speed Boost", 0) == 1 && Input.GetAxis("Jump") == 1)
        {
            return 250.0f;
        }
        else{
            return 150.0f;
        }
    }

    public float upgradeTurning()
    {
        if(PlayerPrefs.GetInt("Faster Turning", 0) == 1)
        {
            return 300.0f;
        }
        else{
            return 180.0f;
        }
    }

    public bool dying() {
        return PlayerPrefs.GetInt("Nonlethal Collisions", 0) == 0;
    }

    public int fertileDirtUpgrade(int currentRequirement)
    {
        if(PlayerPrefs.GetInt("More Fertile Dirt", 0) == 1)
        {
            return (int)0.6f * currentRequirement;
        }
        else{
            return currentRequirement;
        }
    }

    public bool universalDirtUpgrade()
    {
        return !(PlayerPrefs.GetInt("Universal Dirt", 0) == 1);
    }
}
