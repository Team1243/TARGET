using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollision : MonoBehaviour
{
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
                GameManager.Instance.GameOver();
                break;
            case "Enemy":
                _dieEnemyCount++;
                if (RoundSystem.Instance.enemySpawnCount <= _dieEnemyCount)
                    GameManager.Instance.GameClear();
                else
                    StartCoroutine(CollisionBullet());
                break;
            case "BulletDelLine":
                StartCoroutine(CollisionBullet());
                break;
            case "OutLine":
            case "WhiteBuilding":
                break;
            default:
                Debug.LogError($"{other.name} is none tag Object");
                break;
        }
    }

    private IEnumerator CollisionBullet() // Bullet이 무언가에 닿아서 재시작/게임종료가 필요할떄 실행 
    {
        GameManager.Instance.gameState = GameState.End;
        DestroyObject();
        yield return new WaitForSeconds(1.5f);
        _knife.ReGame();
        Destroy(gameObject);
    }

    private void DestroyObject()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
