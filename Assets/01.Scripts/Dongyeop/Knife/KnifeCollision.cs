using System.Collections;
using UnityEngine;

public class KnifeCollision : MonoBehaviour
{
    [SerializeField] private GameObject _particle;
    [SerializeField] private AudioSource _audioSource;
    private Knife _knife;
    private int _dieEnemyCount = 0;

    private void Awake() 
    {
        _knife = GameObject.Find("Player").GetComponent<Knife>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        string collisionName = other.tag;

        switch (collisionName)
        {
            case "NormalHuman":
                _audioSource.Play();
                if (GameManager.Instance.gameState == GameState.End)
                    return;
                CollisionNormalHuman();
                break;
            case "Enemy":
                CollisionEnemy(other);
                break;
            case "BulletDelLine":
                StartCoroutine(CollisionBullet());
                break;
            case "Other":
            case "OutLine":
            case "WhiteBuilding":
                break;
            default:
                Debug.LogError($"{other.name} is none tag Object");
                break;
        }
    }

    private void CollisionNormalHuman()
    {
        CameraManager.Instance.CameraShake();
        GameManager.Instance.GameOver();
        Instantiate(_particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void CollisionEnemy(Collider2D other)
    {
        _audioSource.Play();
        if (GameManager.Instance.gameState == GameState.GameOver)
            return;
        CameraManager.Instance.CameraShake();
        _knife.dieEnemyCount++;
        if (RoundSystem.Instance.enemySpawnCount <= _knife.dieEnemyCount)
        {
            GameManager.Instance.GameClear();
            _dieEnemyCount = 0;
            Destroy(other.gameObject);
            StartCoroutine(CollisionBullet());
        }
        else
        {
            Destroy(other.gameObject);
            StartCoroutine(CollisionBullet());
        }
        Instantiate(_particle, transform.position, Quaternion.identity);
    }

    private IEnumerator CollisionBullet() // Bullet이 무언가에 닿아서 재시작/게임종료가 필요할떄 실행 
    {
        GameManager.Instance.gameState = GameState.End;
        DestroyObject();
        yield return new WaitForSeconds(1.3f);
        _knife.ReGame();
        Destroy(gameObject);
    }

    private void DestroyObject()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
