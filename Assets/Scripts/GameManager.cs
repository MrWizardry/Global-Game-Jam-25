using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool stageStarted;

    [SerializeField] private Animator animatorPlayer;
    [SerializeField] private Animator animatorBG;

    [SerializeField] private UpgradeManager upgradeManager;

    [SerializeField] private GameObject gameOverMenu;
    private void Start()
    {
        stageStarted = false;

        upgradeManager = FindFirstObjectByType<UpgradeManager>().GetComponent<UpgradeManager>();
        animatorPlayer = GameObject.Find("JogadorRoot").GetComponent<Animator>();
        animatorBG = GameObject.Find("BackGround").GetComponent<Animator>();
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
    }
    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
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
    public void SetStatus()
    {
        upgradeManager.SetStatus();
    }
    public void UpgradeLife()
    {
        upgradeManager.UpgradeLife();
    }
    public void UpgradeMove()
    {
        upgradeManager.UpgradeMove();
    }
}
