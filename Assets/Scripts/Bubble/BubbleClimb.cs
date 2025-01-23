                using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BubbleClimb : MonoBehaviour
{
    [Header("Settings")]

    public float metersPerSecond = 5f;
    public float maxHeight = 100f;
    public Slider sliderHeight;

    private float elapsedTime = 0f;
    private float height = 0f;

    void Start()
    {
        if(sliderHeight != null)
        {
            sliderHeight.maxValue = maxHeight;
            sliderHeight.value = 0;
        }
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;

        height = elapsedTime * metersPerSecond;

        if(sliderHeight != null)
        {
            sliderHeight.value = Mathf.Clamp(height, 0, maxHeight);
        }
    }
}
