using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleLife : MonoBehaviour
{
    [SerializeField] private int bubbleMaxLife = 1;
    [SerializeField] private int bubbleLife = 1;

    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>().GetComponent<GameManager>();
    }
    public void SetLife(int value)
    {
        bubbleMaxLife = value;
        bubbleLife = value;
    }

    public void TakeDamage(int damage)
    {
        bubbleLife -= damage;

        if(bubbleLife <= 0)
        {
            Die();
        }

    }

    public void Heal(int heal)
    {
        bubbleLife += heal;

        if(bubbleLife > bubbleMaxLife)
        {
            bubbleLife = bubbleMaxLife;
        }
    }

    private void Die()
    {
        gameManager.GameOver();
    }

}
