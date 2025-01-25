using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] private float speed =   2f;
    [SerializeField] private Vector2 direction;

    [SerializeField] private FeatherVFX vfxTrail;
    [SerializeField] private GameObject vfx;
    private Rigidbody2D rb2D;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = direction * speed;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Deleter")
        {
            if(vfxTrail != null) vfxTrail.DetachParticles();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            
            BubbleLife playerLife = collision.GetComponent<BubbleLife>();
            if (playerLife != null)
            {
                playerLife.TakeDamage(1);
                audioManager.PlaySFX(audioManager.hurt);
            }
            Instantiate(vfx,transform.position, Quaternion.identity);
            if (vfxTrail != null) vfxTrail.DetachParticles();
            Destroy(this.gameObject);
        }
    }
}
