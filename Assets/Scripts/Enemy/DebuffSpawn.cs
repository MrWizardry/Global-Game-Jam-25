using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffSpawn : MonoBehaviour
{
    [SerializeField] private GameObject m_SpawnObject;
    [SerializeField] private Vector2 spawnRange;
    private Vector3 spawnPos;
    [SerializeField] private float spawnInterval;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        StartCoroutine(Spawn());
    }
    public IEnumerator Spawn()
    {

        while (gameManager.GetStageStarted() == false)
        {
            //Debug.Log(manager.GetStageStarted());
            yield return null;
        }
        while (gameManager.GetStageStarted() == true)
        {
            //Debug.Log("Spawning");
            yield return new WaitForSeconds(spawnInterval);
            ChooseSpawnPosition();

            Instantiate(m_SpawnObject, spawnPos, Quaternion.identity);
        }
    }
    private void ChooseSpawnPosition()
    {
        float posX = Random.Range(spawnRange.x, -spawnRange.x);
        float posY = Random.Range(spawnRange.y, -spawnRange.y);
        spawnPos = new Vector3(posX, posY, 0);
    }
}
