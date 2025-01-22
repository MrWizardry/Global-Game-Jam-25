using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed =   2f;
    [SerializeField] private Vector2 direction;
    private Rigidbody2D rb2D;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Deleter")
        {
            Destroy(this.gameObject);
        }
        if(collision.collider.tag == "Player")
        {
            BubbleLife playerLife = collision.collider.GetComponent<BubbleLife>();
            if (playerLife != null)
            {
                playerLife.TakeDamage(1);
            }
        }
    }
}
