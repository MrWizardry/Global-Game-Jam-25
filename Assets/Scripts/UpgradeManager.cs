using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] UpgradesSO bubbleStatus;

    #region STATUS
    [SerializeField] private int bubbleMaxLife;
    [SerializeField] private int lifeMaxUp;
    public int lifeUpCount = 0;

    [SerializeField] private int bubbleMaxArea;
    [SerializeField] private int maxAreaUp;
    public int areaUpCount = 0;
    #endregion

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
        if (lifeUpCount < lifeMaxUp)
        {
            bubbleMaxLife++;
            lifeUpCount++;
        }
    }
    public void UpgradeMove()
    {
        if (areaUpCount < 15)
        {
            bubbleMaxArea--;
            areaUpCount++;
        }
    }
}
