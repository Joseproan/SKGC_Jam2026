using UnityEngine;
using Unity.Services.Leaderboards;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI scoreDisplayFeedback;
    private Animator scoreEffect;

    void Awake()
    {
        scoreEffect = scoreDisplayFeedback.GetComponent<Animator>();
    }
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
        scoreDisplayFeedback.text = "+" + points.ToString();
        scoreEffect.SetTrigger("ScoreUp");
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
    public void SubmitScoreToLeaderboard()
    {
        //LeaderboardsService.Instance.AddPlayerScoreAsync("highscores", score);
    }
}
