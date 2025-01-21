using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemySpawnPoints;
    public List<GameObject> objectsToSpawn;
    [SerializeField] float spawnInterval = 2f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemyAtRandomPoint();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemyAtRandomPoint()
    {
        if(enemySpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0,enemySpawnPoints.Count);
            GameObject spawnPoint = enemySpawnPoints[randomIndex];

            int randomObejct = Random.Range(0, objectsToSpawn.Count);
            GameObject spawnObject  = objectsToSpawn[randomObejct];

            Instantiate(spawnObject, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
