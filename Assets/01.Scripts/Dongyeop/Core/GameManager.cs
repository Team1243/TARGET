using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState = GameState.Ready; // 현재 게임의 상태를 표시하는 Enum
    public int knifeIndex = 5; // 칼이 얼마나 남아있는지 

     private void Awake() 
     {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        gameState = GameState.Ready;    
     }
}
