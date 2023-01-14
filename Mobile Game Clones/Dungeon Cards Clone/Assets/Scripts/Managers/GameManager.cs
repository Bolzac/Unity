using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action OnRoundChange = delegate { };
    public static GameManager Instance;
    
    public int round;
    public int score;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        round = 0;
        score = 0;
        Instance = this;
    }

    public void MoveNextRound()
    {
        round++;
        scoreText.text = $"Gold: {round.ToString()}";
        OnRoundChange();
    }
}

public enum GameState
{
    GenerateGrid,
    Await,
    Action
}