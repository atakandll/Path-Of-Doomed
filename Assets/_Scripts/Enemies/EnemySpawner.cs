using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab = null;

    [SerializeField]
    private List<GameObject> spawnPoints = null;

    [SerializeField]
    private int count = 20;

    [SerializeField]
    private float minDelay = 0.8f, maxDelay = 1.5f;

    IEnumerator SpawnCoroutine()
    {
        while (count > 0)
        {
            count--;
            var randomIndex = Random.Range(0, spawnPoints.Count);

            var randomOffset = Random.insideUnitCircle; // Sets the position to be somewhere inside a circle
            var spawnPoint = spawnPoints[randomIndex].transform.position + (Vector3)randomOffset;

            SpawnEnemy(spawnPoint);

            var randomTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(randomTime);
        }
    }

    private void SpawnEnemy(Vector3 spawnPoint)
    {
        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
    }

    private void Start()
    {
        if (spawnPoints.Count > 0)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                SpawnEnemy(spawnPoint.transform.position);

            }
        }
        StartCoroutine(SpawnCoroutine());

    }
}
