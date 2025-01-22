using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGGameStart : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>().GetComponent<GameManager>();
    }
    private void StartGame()
    {
        gameManager.StartStage();
    }
}
