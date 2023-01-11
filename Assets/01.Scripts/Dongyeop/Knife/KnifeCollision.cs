using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollision : MonoBehaviour
{
    private Knife _knife;

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
                print("Game Over");
                GameManager.Instance.gameState = GameState.End;
                StartCoroutine(CollisionBullet());
                break;
            case "Enemy":
                print("Enemy Die");
                GameManager.Instance.gameState = GameState.End;
                StartCoroutine(CollisionBullet());
                break;
            case "OutLine":
                print ("Collision OutLine");
                StartCoroutine(CollisionBullet());
                break;
            default:
                Debug.LogError($"{other.name} is none tag Object");
                GameManager.Instance.gameState = GameState.End;
                break;
        }
    }

    private IEnumerator CollisionBullet() // Bullet이 무언가에 닿아서 재시작/게임종료가 필요할떄 실행 
    {
        print(1);
        yield return new WaitForSeconds(1);
        print(2);
        _knife.ReGame();
        print(3);
        Destroy(gameObject);
        print(4);
    }
}
