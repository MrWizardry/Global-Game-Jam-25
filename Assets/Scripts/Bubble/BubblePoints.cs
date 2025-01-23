using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BubblePoints : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text inGameScoreText; // Exibe a pontuação durante o jogo
    public TMP_Text gameOverScoreText; // Exibe a pontuação final na tela de Game Over
    public TMP_Text menuTotalScoreText; // Exibe a pontuação geral no menu principal

    [Header("Score Settings")]
    public float scoreMultiplier = 10f; // Quantos pontos por segundo

    private float elapsedTime = 0f; // Tempo total de sobrevivência
    private int currentSessionScore = 0; // Pontuação da partida atual
    private int totalScore = 0; // Pontuação acumulada de todas as partidas


    private UpgradeManager upgradeManager;
    void Start()
    {
        upgradeManager = FindFirstObjectByType<UpgradeManager>().GetComponent<UpgradeManager>();
        totalScore = upgradeManager.GetTotalPoints();
        // Exibe a pontuação acumulada no menu, se aplicável
        if (menuTotalScoreText != null)
        {
            menuTotalScoreText.text = $"Total Score: {totalScore}";
        }
    }

    void Update()
    {
        // Atualiza o tempo e calcula a pontuação da partida atual
        elapsedTime += Time.deltaTime;
        currentSessionScore = Mathf.FloorToInt(elapsedTime * scoreMultiplier);

        // Atualiza a UI da pontuação em tempo real (durante o jogo)
        if (inGameScoreText != null)
        {
            inGameScoreText.text = $"Score: {currentSessionScore}";
        }

        if (totalScore != upgradeManager.GetTotalPoints())
        {
            ChangeUI();
        }
    }

    // Chamado quando o jogador perde (por exemplo, ao entrar na tela de Game Over)
    public void OnGameOver()
    {
        // Atualiza a pontuação acumulada
        totalScore += currentSessionScore;

        // Atualiza o texto da pontuação final na tela de Game Over
        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = $"Game Over Score: {currentSessionScore}";
        }

        upgradeManager.SetTotalPoints(totalScore);
        // Reseta o tempo e a pontuação da partida atual para a próxima partida
        ResetSessionScore();
    }
    public void ChangeUI()
    {
        totalScore = upgradeManager.GetTotalPoints();
        // Atualiza o texto do menu principal, se aplicável
        if (menuTotalScoreText != null)
        {
            menuTotalScoreText.text = $"Total Score: {totalScore}";
        }

    }
    private void ResetSessionScore()
    {
        elapsedTime = 0f;
        currentSessionScore = 0;
    }


}
