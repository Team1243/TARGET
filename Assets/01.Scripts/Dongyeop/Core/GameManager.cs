using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public gamestate gamestate = gamestate.Ready; // 현재 게임의 상태를 표시하는 Enum

     private void Awake() 
     {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        gamestate = gamestate.Ready;    
     }

     public void GameOver()
     {
        gamestate = gamestate.End;
        print("Game OVer");
     }
}
