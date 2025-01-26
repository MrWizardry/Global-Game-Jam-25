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


    [SerializeField] private GameManager manager;
    private bool gameEnd;
    void Start()
    {
        gameEnd = false;
        manager = FindFirstObjectByType<GameManager>().GetComponent<GameManager>();

        if(sliderHeight != null)
        {
            sliderHeight.maxValue = maxHeight;
            sliderHeight.value = 0;
        }
    }
    void Update()
    {
        if(height >= maxHeight && !gameEnd)
        {
            manager.GameWin();
            gameEnd = true;
        }
        else
        {
            elapsedTime += Time.deltaTime;

            height = elapsedTime * metersPerSecond;

            if (sliderHeight != null)
            {
                sliderHeight.value = Mathf.Clamp(height, 0, maxHeight);
            }
        }
    }
}
