using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [Header("SpawnPoints")]
    public List<GameObject> enemySpawnPoints;
    public List<GameObject> alternateSpawnPoints;
    [SerializeField] float initialspawnInterval = 2f;
    private float spawnInterval;
    private float gameTime= 0f;
    [SerializeField] private EnemySpawn spawnHere; //para chamar no script do spawn

    [SerializeField] private GameManager manager;
    [Header("O bagulho da Altura & Ponto")]
    public GameObject bubbleClimb;
    public GameObject sliderHeight;
    public GameObject bubblePoints;
    void Start()
    {
        sliderHeight.SetActive(false);
        bubbleClimb.SetActive(false);
        
        manager = GetComponent<GameManager>();
        spawnInterval = initialspawnInterval;
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        UpdateSpawnBehavior();
    }

    public IEnumerator SpawnEnemies()
    {
        
        while (manager.GetStageStarted() == false)
        {
            //Debug.Log(manager.GetStageStarted());
            yield return null;
        }
        while (manager.GetStageStarted() == true)
        {
            //Debug.Log("Spawning");
            yield return new WaitForSeconds(spawnInterval);
            ChooseSpawnPoint();
            sliderHeight.SetActive(true);
            bubbleClimb.SetActive(true);
            bubblePoints.SetActive(true);
            if(spawnHere != null)
            {
                spawnHere.CallWarning();
                yield return new WaitForSeconds(1f);
                spawnHere.SpawnEnemy();
                Debug.Log("Spawned");
            }

            Debug.Log("endWhile");
        }
    }
    void ChooseSpawnPoint()
    {
        List<GameObject> currentSpawnPoints = GetAvailableSpawnPoints();
        if (currentSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, currentSpawnPoints.Count);
            GameObject spawnPoint = currentSpawnPoints[randomIndex];
            spawnHere = spawnPoint.GetComponent<EnemySpawn>();
        }
    }

    List<GameObject> GetAvailableSpawnPoints()
    {
        if (gameTime < 30f) // Primeiros 30 segundos
        {
            return enemySpawnPoints;
        }
        else if (gameTime < 60f) // Entre 30 e 60 segundos
        {
            return alternateSpawnPoints;
        }
        else // Após 60 segundos
        {
            List<GameObject> combined = new List<GameObject>(enemySpawnPoints);
            combined.AddRange(alternateSpawnPoints);
            return combined;
        }
    }

    void UpdateSpawnBehavior()
    {
        if (gameTime > 30f && gameTime <= 60f)
        {
            spawnInterval = 1.5f; // Aumenta a frequência do spawn
        }
        else if (gameTime > 60f)
        {
            spawnInterval = 1f; // Frequência ainda maior após 60 segundos
        }
    }
}
