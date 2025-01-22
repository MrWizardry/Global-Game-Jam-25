using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bubble_Status", menuName = "Status/New Bubble Status")]
public class UpgradesSO : ScriptableObject
{
    [SerializeField] private int bubbleLifeMax;
    [SerializeField] private int bubbleArea;

    public int BubbleLifeMax => bubbleLifeMax;
    public int BubbleArea => bubbleArea;
}
