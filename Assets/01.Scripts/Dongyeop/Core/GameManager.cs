using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header ("Core")]
    public static GameManager Instance;
    public GameState gameState = GameState.Ready; // 현재 게임의 상태를 표시하는 Enum

    [Header ("Events")]
    [SerializeField] private UnityEvent _gameClear;
    [SerializeField] private UnityEvent _gameOver;

    private int _enemyIndex;
    private int _humanIndex;

     private void Awake() 
     {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        gameState = GameState.Ready;
        RoundSystem.Instance.RoundLoop(); 
     }

     public void GameClear()
     {
        gameState = GameState.GameClear;
        _gameClear?.Invoke();
        print("Game Clear");
     }

     public void GameOver()
     {
        gameState = GameState.GameOver;
        _gameOver?.Invoke();
        print("Game Over");
     }
}
