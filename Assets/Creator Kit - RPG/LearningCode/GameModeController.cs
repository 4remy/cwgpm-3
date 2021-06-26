using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeController : MonoBehaviour
{
    public enum GameMode
    {
         Paused,
         Active,
         GameOver
    }
    public GameMode gameMode;
    public bool playerCanMove;
    public bool enemiesCanMove;
    public bool spawnNewEnemies;
    public float timeScale;

    // update is called once per frame
    void Update()
    {
        switch (gameMode)
        {
            case GameMode.Paused:
                playerCanMove = false;
                enemiesCanMove = false;
                spawnNewEnemies = false;
                timeScale = 0;
                break;
            case GameMode.Active:
                playerCanMove = true;
                enemiesCanMove = true;
                spawnNewEnemies = true;
                timeScale = 1;
                break;
            case GameMode.GameOver:
                playerCanMove = false;
                enemiesCanMove = true;
                spawnNewEnemies = false;
                timeScale = 1;
                break;
        }
    }
}