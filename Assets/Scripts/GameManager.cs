using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool stageStarted;

    [SerializeField] private Animator animatorPlayer;
    [SerializeField] private Animator animatorBG;

    private void Start()
    {
        stageStarted = false;
    }
    public bool GetStageStarted()
    {
        return stageStarted;
    }
    public void StartStage()
    {
        stageStarted = true;
    }
    public void StartGameAnim()
    {
        animatorPlayer.SetTrigger("StartGame");
        animatorBG.SetTrigger("StartGame");
    }
}
