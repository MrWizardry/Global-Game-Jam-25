using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy : MonoBehaviour
{
    private BirdStage actualStage;
    [SerializeField] private float maxTimeToStop;
    [SerializeField] private float minTimeToStop;
    private float timeToStop;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float timer;
    [SerializeField] private float dashForce;   

    private Rigidbody2D rb2D;
    private Animator animator;
    private AudioManager audioManager;

    [SerializeField] private GameObject playerGB;

    [Header("Bird VFX")]
    [SerializeField] private GameObject trailGO;
    [SerializeField] private GameObject stopVFX;

    private void Start()
    {
        playerGB = GameObject.Find("Jogador");
        actualStage = BirdStage.stage1;

        rb2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();

        timeToStop = Random.Range(minTimeToStop, maxTimeToStop);

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void FixedUpdate()
    {
        switch (actualStage)
        {
            case BirdStage.stage1:
                timeToStop -= Time.fixedDeltaTime;

                if (timeToStop < 0)
                {
                    rb2D.velocity = Vector3.zero;
                    actualStage = BirdStage.stage2;
                    animator.Play("Phase_02");
                    CallStopVFX();
                }
                //Debug.Log(actualStage);
                break;

            case BirdStage.stage2:
                TrackPlayer();
                timer -= Time.fixedDeltaTime;
                if (timer < 0)
                {
                    actualStage = BirdStage.stage3;
                    animator.Play("Phase_03");
                    trailGO.SetActive(true);
                    CallStopVFX();

                    audioManager.PlaySFX(audioManager.Bird_Attack);
                }
                //Debug.Log(actualStage);
                break;
            case BirdStage.stage3 :
                
                rb2D.velocity = this.gameObject.transform.right * dashForce;
                //Debug.Log(actualStage);
                break;
        }
    }
    private void TrackPlayer()
    {
        float angle = Mathf.Atan2(playerGB.transform.position.y - transform.position.y, playerGB.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void CallStopVFX()
    {
        GameObject obj = Instantiate(stopVFX, transform.position, Quaternion.identity);
        Destroy(obj, 1f);
    }
}
public enum BirdStage
{
    stage1,stage2,stage3
}

