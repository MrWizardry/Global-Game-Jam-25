using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] UpgradesSO bubbleStatus;
    [Header("Points")]
    private int totalPoints;

    #region STATUS
    [Header("Life")]
    [SerializeField] private int bubbleMaxLife;
    [SerializeField] private int lifeMaxUp;
    [SerializeField] private int lifeUpPrice;
    public int lifeUpCount = 0;

    [Header("Move Area")]
    [SerializeField] private int bubbleMaxArea;
    [SerializeField] private int maxAreaUp;
    [SerializeField] private int moveAreaUpPrice;
    public int areaUpCount = 0;
    #endregion

    [Header("Debug")]
    [SerializeField] private BubbleLife bubbleLife;
    [SerializeField] private MoveBubble bubbleMove;

    private void Start()
    {
        bubbleLife = FindFirstObjectByType<BubbleLife>().GetComponent<BubbleLife>();
        bubbleMove = FindFirstObjectByType<MoveBubble>().GetComponent<MoveBubble>();


        bubbleMaxLife = bubbleStatus.BubbleLifeMax;
        bubbleMaxArea = bubbleStatus.BubbleArea;
    }
    private void Update()
    {
        if(bubbleMove == null)
        {
            bubbleLife = FindFirstObjectByType<BubbleLife>().GetComponent<BubbleLife>();
            bubbleMove = FindFirstObjectByType<MoveBubble>().GetComponent<MoveBubble>();
        }
    }
    public void SetStatus()
    {
        bubbleLife.SetLife(bubbleMaxLife);
        bubbleMove.SetBubbleArea(bubbleMaxArea);
    }
    public void UpgradeLife()
    {
        if (lifeUpCount < lifeMaxUp && totalPoints >= lifeUpPrice)
        {
            bubbleMaxLife++;
            lifeUpCount++;

            totalPoints -= lifeUpPrice;
        }
    }
    public void UpgradeMove()
    {
        if (areaUpCount < 15 && totalPoints >= moveAreaUpPrice)
        {
            bubbleMaxArea--;
            areaUpCount++;

            totalPoints -= moveAreaUpPrice;
        }
    }
    public int GetTotalPoints()
    {
        return totalPoints;
    }
    public void SetTotalPoints(int value)
    {
        totalPoints = value;
    }
}
