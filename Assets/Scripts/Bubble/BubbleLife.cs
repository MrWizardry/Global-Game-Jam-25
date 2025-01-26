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

    private Vector3 origScale;
    private bool canTakeDebuff;
    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>().GetComponent<GameManager>();
        canTakeDamage = true;
        canTakeDebuff = true;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        origScale = transform.localScale;
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
        audioManager.PlaySFX(audioManager.death);
        gameManager.GameOver();
    }
    public void GotBigger(float value, float scale)
    {
        StartCoroutine(TimeBigger(value,scale));
    }
    public IEnumerator TimeBigger(float time, float scaleMult)
    {
        if(canTakeDebuff)
        {
            canTakeDebuff = false;
            transform.localScale = origScale * scaleMult;
            yield return new WaitForSeconds(time);
            transform.localScale = origScale;
            canTakeDebuff = true;
        }
    }

}
