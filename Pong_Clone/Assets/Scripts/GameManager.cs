using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Ball ball;

    [SerializeField] Paddle playerPaddle;
    private int playerScore;
    [SerializeField] Text playerScoreText;

    [SerializeField] Paddle computerPaddle;
    private int computerScore;
    [SerializeField] Text computerScoreText;

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ResetGame();
        }
    }

    void Start()
    {
        ResetGame();
    }
    void ResetGame()
    {
        startRound();
        setComputerScore(0);
        setPlayerScore(0);
    }
    void startRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    public void toPlayerScore()
    {
        setPlayerScore(playerScore + 1);
        startRound();
    }

    public void toComputerScore()
    {
        setComputerScore(computerScore + 1);
        startRound();
    }
    private void setPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = $"{playerScore}";
    }
    private void setComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = $"{computerScore}";
    }
}
