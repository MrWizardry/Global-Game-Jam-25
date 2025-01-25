using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject warning;

    [SerializeField] private Transform warningPos;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void CallSpawn()
    {
        SpawnWarning();

    }
    private void SpawnWarning()
    {
        GameObject obj = Instantiate(warning, warningPos.position, Quaternion.identity);
        audioManager.PlaySFX(audioManager.Warning);
        Destroy(obj,1f);
    }
    public void CallWarning()
    {
        SpawnWarning();
    }
    public void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, enemy.transform.rotation);
    }
}
