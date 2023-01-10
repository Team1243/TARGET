using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    [Header("Spawn Position")]
    public Vector2 leftSpawnPosition;
    public Vector2 rightSpawnPosition;

    [Header("Prefab")]
    public Enemy enemyPrefab;
    public Human humanPrefab;

    [Header("Spawn Count")]
    public int enemySpawnCount;
    public int humanSpawnCount;

    [ContextMenu("���� �׽�Ʈ")]
    public void SpawnTest()
    {
        for (int i = 0; i < enemySpawnCount; i++)
        {
            Instantiate(enemyPrefab);
            
            float random = Random.Range(leftSpawnPosition.x, rightSpawnPosition.x);
            Vector3 spawnPosition = new Vector3((float)random, leftSpawnPosition.y, 0);

            enemyPrefab.transform.position = spawnPosition;
        }

        for (int i = 0; i < humanSpawnCount; i++)
        {
            Instantiate(humanPrefab);

            float random = Random.Range(leftSpawnPosition.x, rightSpawnPosition.x);
            Vector3 spawnPosition = new Vector3((float)random, leftSpawnPosition.y, 0);

            humanPrefab.transform.position = spawnPosition;
        }
    }
}
