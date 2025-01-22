using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("SpawnPoints")]
    public List<GameObject> enemySpawnPoints;



    [SerializeField] float spawnInterval = 2f;
    private EnemySpawn spawnHere; //para chamar no script do spawn
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            ChooseSpawnPoint();
            spawnHere.CallWarning();
            yield return new WaitForSeconds(1f);
            spawnHere.SpawnEnemy();
        }
    }
    void ChooseSpawnPoint()
    {
        if (enemySpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, enemySpawnPoints.Count);
            GameObject spawnPoint = enemySpawnPoints[randomIndex];
            spawnHere = spawnPoint.GetComponent<EnemySpawn>();
        }
    }
}
