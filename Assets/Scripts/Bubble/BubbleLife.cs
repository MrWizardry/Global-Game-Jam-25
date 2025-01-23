using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleLife : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] private int bubbleMaxLife = 1;
    [SerializeField] private int bubbleLife = 1;

    [SerializeField] private Animator spriteAnimation;

    [SerializeField] private bool canTakeDamage;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>().GetComponent<GameManager>();
        canTakeDamage = true;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void SetLife(int value)
    {
        bubbleMaxLife = value;
        bubbleLife = value;
    }

    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            bubbleLife -= damage;
            if (bubbleLife <= 0) Die();

            else spriteAnimation.Play("Hurt");
            canTakeDamage = false;
        }
        else return;
    }
    public void CanTakeDamageNow()
    {
        canTakeDamage = true;
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
        spriteAnimation.Play("Die");
        audioManager.PlaySFX(audioManager.one);

        gameManager.GameOver();
    }

}
