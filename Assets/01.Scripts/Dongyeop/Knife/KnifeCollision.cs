using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        string collisionName = other.tag;

        switch (collisionName)
        {
            case "NormalHuman":
                print("Game Over");
                GameManager.Instance.gameState = GameState.End;
                break;
            case "Enemy":
                print("Enemy Die");
                GameManager.Instance.gameState = GameState.End;
                break;
            case "OutLine":
                print ("Collision OutLine");
                break;
            default:
                Debug.LogError($"{other.name} is none tag Object");
                GameManager.Instance.gameState = GameState.End;
                break;
        }
    }

    private void CollisionBullet() // Bullet이 무언가에 닿아서 재시작/게임종료가 필요할떄 실행 
    {

    }
}
