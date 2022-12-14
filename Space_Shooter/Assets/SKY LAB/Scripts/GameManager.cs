using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI _scoreText;
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

    public Slider _healthSlider;
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
    public TextMeshProUGUI _waveText;
    private int _enemyCount = 5;
    public int EnemyCount
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

    private GameManager _gameManager;
    private Spawner _spawner;
    public GameObject LosePanel;
    public GameObject InGamePanel;

    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();
        _spawner = FindObjectOfType<Spawner>();
    }

    private void Start()
    {
        //Open menu on the start of game
        NewGame();
    }

    private void Update()
    {
        //Check for Wave's enemy number
        if (EnemyCount <= 0)
        {
            Invoke(nameof(NextWave),2); //If all enemies are destroyed, then go to next wave after 2 seconds
            EnemyCount = 5;// Reset enemy number
        }
        SetUI();
    }

    private void SetUI()
    {
        _waveText.SetText(Wave.ToString());
        _scoreText.SetText(score.ToString());
        _healthSlider.value = Health;
    }
    public void NewGame()
    {
        //Starts to gameplay
        Health = 3;
        Wave = 1;
        score = 0;
        InGamePanel.SetActive(true);
        LosePanel.SetActive(false);
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(2);
    }

    public void NextWave()
    {
        Wave++;
    }

    public void LoseGame()
    {
        LosePanel.SetActive(true);
        InGamePanel.SetActive(false);
        Time.timeScale = 0;
    }
}