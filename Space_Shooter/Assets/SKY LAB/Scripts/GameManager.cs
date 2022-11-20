using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    private int _health = 3;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (value < 3 && value > -1)
            {
                _health = value;
            }
        }
    }
    private int _wave = 1;

    public int Wave
    {
        get
        {
            return _wave;
        }
        set
        {
            if (value > 0)
            {
                _wave = value;
            }
        }
    }
    private static int _enemyCount = 5;
    public static int EnemyCount
    {
        get
        {
            return _enemyCount;
        }
        set
        {
            if (value >= 0 && value <= 20)
            {
                _enemyCount = value;
            }
            else
            {
                throw new Exception("Enemy count value's interval is between 0 and 30");
            }
        }
    }
    private void Start()
    {
        //Open menu on the start of game
        NewGame();
    }

    private void Update()
    {
        //Check for Player's health
        if (Health <= 0)
        {
            LoseGame();
        }
        //Check for Wave's enemy number
        if (EnemyCount <= 0)
        {
            Invoke(nameof(NextWave),2); //If all enemies are destroyed, then go to next wave after 2 seconds
            EnemyCount = 5;// Reset enemy number
        }
    }

    private void NewGame()
    {
        //Starts to gameplay
        Health = 3;
        Wave = 1;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(2);
    }

    public void NextWave()
    {
        var wave = Wave;
        Wave = wave + 1;
    }

    private void LoseGame()
    {
        SceneManager.LoadScene(3);
    }
}