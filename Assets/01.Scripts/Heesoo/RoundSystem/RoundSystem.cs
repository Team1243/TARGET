using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    // 현재 라운드수
    private int roundCount = 0;
    // 남아있는 적, 시민 리스트
    private List<GameObject> enemyAndHuman = new ();

    [Header("Spawn Position")]
    public Vector2 leftSpawnPosition;
    public Vector2 rightSpawnPosition;

    [Header("Prefab")]
    public Enemy enemyPrefab;
    public Human humanPrefab;
    private Enemy _enemy;
    private Human _human;

    [Header("Spawn Count")]
    public int enemySpawnCount;
    public int humanSpawnCount;

    private void Awake()
    {
        _enemy = enemyPrefab.GetComponent<Enemy>();
        _human = humanPrefab.GetComponent<Human>();
    }

    [ContextMenu("스폰 테스트")]
    public void RoundStart()
    {
        StartCoroutine(NextRound());
    }

    IEnumerator NextRound()
    {
        roundCount++;

        Spwan();
        ChangeProperty();

        yield return null;
    }

    public void Spwan()
    {
        // 에너미 소환
        for (int i = 0; i < enemySpawnCount; i++)
        {
            Instantiate(enemyPrefab);
            
            float random = Random.Range(leftSpawnPosition.x, rightSpawnPosition.x);
            Vector3 spawnPosition = new Vector3((float)random, leftSpawnPosition.y, 0);

            enemyPrefab.transform.position = spawnPosition;
        }

        // 시민 소환
        for (int i = 0; i < humanSpawnCount; i++)
        {
            Instantiate(humanPrefab);

            float random = Random.Range(leftSpawnPosition.x, rightSpawnPosition.x);
            Vector3 spawnPosition = new Vector3((float)random, leftSpawnPosition.y, 0);

            humanPrefab.transform.position = spawnPosition;
        }
    }

    public void ChangeProperty()
    {
        // 생성수 조정
        // round 수가 5의 배수
        if (roundCount % 5 == 0)
        {
            enemySpawnCount++;
        }
        // round 수가 4의 배수
        else if (roundCount % 3 == 0)
        {
            humanSpawnCount++;
        }

        // 생성물들 속도 조정
        _enemy.moveSpeed *= 1.05f;
        _human.moveSpeed *= 1.05f;

        // 조준 속도 조정
    }

    // 남아있는 Enemy, Human 가져와서 삭제
    [ContextMenu("리셋")]
    public void AllClear()
    {
        print("AllClear");
        
        
    }
}
