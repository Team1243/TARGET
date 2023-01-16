using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header ("Core")]
    public static GameManager Instance;
    public GameState gameState = GameState.Title; // 현재 게임의 상태를 표시하는 Enum

    [Header ("Events")]
    [SerializeField] private UnityEvent _gameClear;
    [SerializeField] private UnityEvent _gameOver;

    [Header ("UI")]
    [SerializeField] private GameObject _titleUI; 
    [SerializeField] private GameObject _gameOverUI;
    
    private Knife _knife;
    private int _enemyIndex;
    private int _humanIndex;

     private void Awake() 
     {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        gameState = GameState.Title;
        _knife = GameObject.Find("Player").GetComponent<Knife>();

        Application.targetFrameRate = 60;
     }

    private void Start()
    {
        RoundSystem.Instance.RoundLoop(); 
    }

    private void Update() 
    {
        if (gameState == GameState.Title && (Input.GetMouseButtonDown(0)))
        {
            _titleUI.SetActive(false);
            gameState = GameState.Ready;
        }    
        else if ((gameState == GameState.GameOver && (Input.GetMouseButtonDown(0))) && _knife.isKnifeMoveEnd)
        {
            _gameOverUI.SetActive(false);
            gameState = GameState.Ready;
        }
    }

    public void GameClear()
     {
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
