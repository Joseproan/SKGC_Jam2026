using UnityEngine;
using Unity.Services.Leaderboards;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreDisplay;

    void Start()
    {
        score = 0;
        scoreDisplay.text = (score).ToString();
    }

    void Update()
    {
        scoreDisplay.text = (score).ToString();
    }

    public void AddScore(int points)
    {
        score += points;
    }
}
