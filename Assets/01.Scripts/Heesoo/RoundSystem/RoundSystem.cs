using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    // ���� �����
    private int roundCount = 0;
    // �����ִ� ��, �ù� ����Ʈ
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

    [ContextMenu("���� �׽�Ʈ")]
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
        // ���ʹ� ��ȯ
        for (int i = 0; i < enemySpawnCount; i++)
        {
            Instantiate(enemyPrefab);
            
            float random = Random.Range(leftSpawnPosition.x, rightSpawnPosition.x);
            Vector3 spawnPosition = new Vector3((float)random, leftSpawnPosition.y, 0);

            enemyPrefab.transform.position = spawnPosition;
        }

        // �ù� ��ȯ
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
        // ������ ����
        // round ���� 5�� ���
        if (roundCount % 5 == 0)
        {
            enemySpawnCount++;
        }
        // round ���� 4�� ���
        else if (roundCount % 3 == 0)
        {
            humanSpawnCount++;
        }

        // �������� �ӵ� ����
        _enemy.moveSpeed *= 1.05f;
        _human.moveSpeed *= 1.05f;

        // ���� �ӵ� ����
    }

    // �����ִ� Enemy, Human �����ͼ� ����
    [ContextMenu("����")]
    public void AllClear()
    {
        print("AllClear");
        
        
    }
}
