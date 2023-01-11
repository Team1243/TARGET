using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    // 현재 라운드수
    private int roundCount = 0;
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

    [ContextMenu("스폰")]
    public void Spawn()
    {
        print("Spawn");

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
    [ContextMenu("리셋")]
    public void Reset()
    {
        print("Reset");
        
        for (int i = 0; i < garbage.transform.childCount; i++)
        {
            GameObject obj = transform.GetChild(0).GetChild(i).gameObject;
            Destroy(obj);
        }
    }
}
