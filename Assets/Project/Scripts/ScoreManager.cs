using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score;

    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI scoreDisplayFeedback;

    private Animator scoreEffect;

    private void Awake()
    {
        scoreEffect = scoreDisplayFeedback.GetComponent<Animator>();
    }

    private void Start()
    {
        score = 0;
        scoreDisplay.text = "0";
    }

public int GetScore()
{
    return score;
}
    public void AddScore(int points)
    {
        score += points;

        scoreDisplay.text = score.ToString();
        scoreDisplayFeedback.text = "+" + points;
        scoreEffect.SetTrigger("ScoreUp");
    }

    public void SaveScore()
    {
        GameModeType currentMode =
            (GameModeType)PlayerPrefs.GetInt(
                "GameMode",
                (int)GameModeType.Normal
            );

        string unlockedWord = "";

        if (score >= 50)
        {
            if (currentMode == GameModeType.Normal &&
                PlayerPrefs.GetInt("UnlockedReverse", 0) == 0)
            {
                PlayerPrefs.SetInt("UnlockedReverse", 1);
                unlockedWord = "reverse";
            }

            if (currentMode == GameModeType.Reverse &&
                PlayerPrefs.GetInt("UnlockedMissing", 0) == 0)
            {
                PlayerPrefs.SetInt("UnlockedMissing", 1);
                unlockedWord = "missing";
            }
        }

        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetString("NewUnlockedWord", unlockedWord);
        PlayerPrefs.Save();
    }
}