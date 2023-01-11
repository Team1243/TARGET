using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState = GameState.Ready; // 현재 게임의 상태를 표시하는 Enum

     private void Awake() 
     {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        gameState = GameState.Ready;    
     }

     public void GameOver()
     {
        gameState = GameState.End;
        Debug.Log("Gmae Over");
     }
}
