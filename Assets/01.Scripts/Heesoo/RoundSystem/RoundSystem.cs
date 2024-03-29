using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    public static RoundSystem Instance;

    // 현재 라운드수
    public int roundCount = 0;
    // 생성물 생성 위치
    [SerializeField] private GameObject garbage;

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
        if (Instance == null)
        {
            Instance = this;
        }

        _enemy = enemyPrefab.GetComponent<Enemy>();
        _human = humanPrefab.GetComponent<Human>();
    }

    private void Start()
    {
        Init();
    }

    public void RoundLoop()
    {
        StartCoroutine(NextRound());
    }

    public void GameLoop()
    {
        StartCoroutine(NextGame());
    }

    IEnumerator NextRound()
    {
        ObjectReset();
        ChangeProperty();
        
        yield return null;
        
        Spawn();
    }

    IEnumerator NextGame()
    {
        Init();
        ObjectReset();

        yield return null;
        
        Spawn();
    }

    public void Spawn()
    {
        // 에너미 소환
        for (int i = 0; i < enemySpawnCount; i++)
        {
            Instantiate(enemyPrefab, garbage.transform);
            
            float random = Random.Range(leftSpawnPosition.x, rightSpawnPosition.x);
            Vector3 spawnPosition = new Vector3((float)random, leftSpawnPosition.y, 0);

            enemyPrefab.transform.position = spawnPosition;
        }

        // 시민 소환
        for (int i = 0; i < humanSpawnCount; i++)
        {
            Instantiate(humanPrefab, garbage.transform);

            float random = Random.Range(leftSpawnPosition.x, rightSpawnPosition.x);
            Vector3 spawnPosition = new Vector3((float)random, leftSpawnPosition.y, 0);

            humanPrefab.transform.position = spawnPosition;
        }
    }   

    public void ChangeProperty()
    {
        roundCount++;

        if (roundCount == 5)
        {
            humanSpawnCount++;
        }

        // 생성수 조정
        if (roundCount % 15 == 0 && humanSpawnCount < 4)
        {
            humanSpawnCount++;
        }
        
        if (roundCount % 35 == 0 && enemySpawnCount < 2)
        {
            enemySpawnCount++;
        }

        // 생성물들 속도 조정
        _enemy.moveSpeed *= 1.03f;
        _human.moveSpeed *= 1.03f;
    }

    public void ObjectReset()
    {
        for (int i = 0; i < garbage.transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(0).GetChild(i).gameObject;
            Destroy(obj);
        }
    }

    public void Init()
    {
        // 초기화
        roundCount = 1;
        _enemy.moveSpeed = enemySpeed;
        _human.moveSpeed = humanSpeed;
        enemySpawnCount = 1;
        humanSpawnCount = 0;
    }
}
