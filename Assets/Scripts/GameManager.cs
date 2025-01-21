using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Vertical")]
    public List<GameObject> enemySpawnPoints;
    public List<GameObject> objectsToSpawn;
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
            ChooseSpawnPoint();
            spawnHere.CallWarning();
            yield return new WaitForSeconds(1f);
            spawnHere.SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void ChooseSpawnPoint()
    {
        if(enemySpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0,enemySpawnPoints.Count);
            GameObject spawnPoint = enemySpawnPoints[randomIndex];
            spawnHere = spawnPoint.GetComponent<EnemySpawn>();
        }
    }
}
