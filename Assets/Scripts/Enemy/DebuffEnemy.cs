using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffEnemy : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] private GameObject vfx;

    [SerializeField] private float debuffTime;
    [SerializeField] private float debuffScale;
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            BubbleLife playerLife = collision.GetComponent<BubbleLife>();
            if (playerLife != null)
            {
                playerLife.GotBigger(debuffTime, debuffScale);
                audioManager.PlaySFX(audioManager.two);
            }
            Instantiate(vfx, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
