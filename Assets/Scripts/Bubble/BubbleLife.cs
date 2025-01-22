using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleLife : MonoBehaviour
{
    [SerializeField] private float bubbleMaxLife = 1f;
    private float bubbleLife = 1f;

    void Start()
    {
        bubbleLife = bubbleMaxLife;
    }

    public void TakeDamage(float damage)
    {
        bubbleLife -= damage;

        if(bubbleLife <= 0)
        {
            Die();
        }

    }

    public void Heal(float heal)
    {
        bubbleLife += heal;

        if(bubbleLife > bubbleMaxLife)
        {
            bubbleLife = bubbleMaxLife;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
