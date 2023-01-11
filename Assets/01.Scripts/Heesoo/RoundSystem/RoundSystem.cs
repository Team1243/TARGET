using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    // 현재 라운드수
    private int roundCount = 0;
    // 남아있는 적, 시민 리스트
    private List<GameObject> garbageList = new ();

    [Header("Spawn Position")]
    public Vector2 leftSpawnPosition;
    public Vector2 rightSpawnPosition;

    [Header("Prefab")]
    public GameObject enemyPrefab;
    public GameObject humanPrefab;
    private Enemy _enemy;
    private Human _human;

    [Header("Spawn Count")]
    public int enemySpawnCount;
    public int humanSpawnCount;

    [Header("Reset Speed")]
    public float enemySpeed;
    public float humanSpeed;

    private void Awake()
    {
        _enemy = enemyPrefab.GetComponent<Enemy>();
        _human = humanPrefab.GetComponent<Human>();
    }

    private void Start()
    {
        // 초기화
        _enemy.moveSpeed = enemySpeed;
        _human.moveSpeed = humanSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RoundLoop();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public void RoundLoop()
    {
        StartCoroutine(NextRound());
    }

    IEnumerator NextRound()
    {
        roundCount++;

        Reset();
        Spawn();
        ChangeProperty();

        yield return null;
    }

    public void Spawn()
    {
        print("Spawn");

        // 에너미 소환
        for (int i = 0; i < enemySpawnCount; i++)
        {
            Instantiate(enemyPrefab);
            garbageList.Add(enemyPrefab);
            
            float random = Random.Range(leftSpawnPosition.x, rightSpawnPosition.x);
            Vector3 spawnPosition = new Vector3((float)random, leftSpawnPosition.y, 0);

            enemyPrefab.transform.position = spawnPosition;
        }

        // 시민 소환
        for (int i = 0; i < humanSpawnCount; i++)
        {
            Instantiate(humanPrefab);
            garbageList.Add(humanPrefab);

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
        else if (roundCount % 4 == 0)
        {
            humanSpawnCount++;
        }

        // 생성물들 속도 조정
        _enemy.moveSpeed *= 1.02f;
        _human.moveSpeed *= 1.02f;
    }

    // 남아있는 Enemy, Human 가져와서 삭제
    public void Reset()
    {
        print("Reset");

        foreach (GameObject garbage in garbageList)
        {
            Destroy(garbage);
        }

        garbageList.Clear();
    }
}
