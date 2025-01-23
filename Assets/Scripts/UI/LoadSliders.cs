using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSliders : MonoBehaviour
{
    public GameObject slidersOFF;
    public GameObject sliderON;
    public GameObject sliderMusic;
    public GameObject sliderSFX;

    public void AppearSliders()
    {
        slidersOFF.SetActive(false);
        sliderON.SetActive(true);
        if(sliderON == true)
        {
            sliderMusic.SetActive(true);
            sliderSFX.SetActive(true);
        }
    }

    public void DisappearSliders()
    {
        slidersOFF.SetActive(true);
        sliderON.SetActive(false);
        if(slidersOFF == true)
        {
            sliderMusic.SetActive(false);
            sliderSFX.SetActive(false);
        }
    }
}
