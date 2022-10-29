using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public byte lives;
    public int score;
    public int level;
    public int totalLevel = 2;
    [SerializeField] GameObject PauseMenu;
    public Text livesText;
    public static bool _paused = false;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_paused)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            _paused = true;
        }

        livesText.text = $"{lives}";
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _paused = false;
    }
    
    public void BackMenu()
    {
        _paused = false;
        Time.timeScale = 1;
        Destroy(gameObject);
        SceneManager.LoadScene("Menu");
    }

    public void NewGame()
    {
        lives = 3;
        score = 0;
        
        LoadLevel(1);
    }

    public void LevelComplete()
    {
        score += 1000;
        int nextLevel = level + 1;
        if (nextLevel <= totalLevel)
        {
            LoadLevel(nextLevel);
        }
    }

    public void LoadLevel(int index)
    {
        level = index;
        Camera camera = Camera.main;
        if (camera != null)
        {
            camera.cullingMask = 0;
        }
        
        Invoke(nameof(LoadScene),1);
    }
    
    private void LoadScene()
    {
        SceneManager.LoadScene(level);
    }

    public void LevelFailed()
    {
        lives--;
        if (lives <= 0)
        {
            LoadLevel(1);
        }
        else
        {
            LoadLevel(level);
        }
    }
}
