using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilderVolume : MonoBehaviour
{

    
    public Slider musicSlider;

    public Slider sfxSlider;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //SoundtrackController.instance.setVolume(musicSlider.value);
        Ass.instance.sfx.setVolume(sfxSlider.value);
        Food.instance.sfx.setVolume(sfxSlider.value);
    }
}
