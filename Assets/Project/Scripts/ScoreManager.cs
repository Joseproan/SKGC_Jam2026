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

if (currentMode == GameModeType.Normal)
{
    if (score >= 150 &&
        PlayerPrefs.GetInt("UnlockedCaps", 0) == 0)
    {
        PlayerPrefs.SetInt("UnlockedCaps", 1);
        unlockedWord = "caps";
    }
    else if (score >= 100 &&
             PlayerPrefs.GetInt("UnlockedMath", 0) == 0)
    {
        PlayerPrefs.SetInt("UnlockedMath", 1);
        unlockedWord = "calc";
    }
    else if (score >= 50 &&
             PlayerPrefs.GetInt("UnlockedReverse", 0) == 0)
    {
        PlayerPrefs.SetInt("UnlockedReverse", 1);
        unlockedWord = "reverse";
    }
}
    else if (currentMode == GameModeType.Reverse)
    {
        if (score >= 50 &&
            PlayerPrefs.GetInt("UnlockedMissing", 0) == 0)
        {
            PlayerPrefs.SetInt("UnlockedMissing", 1);
            unlockedWord = "missing";
        }
    }
    else if (currentMode == GameModeType.MissingLetters)
{
    if (score >= 50 &&
        PlayerPrefs.GetInt("UnlockedRandom", 0) == 0)
    {
        PlayerPrefs.SetInt("UnlockedRandom", 1);
        unlockedWord = "random";
    }
    else if (currentMode == GameModeType.Random)

{

    if (score >= 75 &&

        PlayerPrefs.GetInt("UnlockedFlash", 0) == 0)

    {

        PlayerPrefs.SetInt("UnlockedFlash", 1);

        unlockedWord = "flash";

    }

}
}

    PlayerPrefs.SetInt("Score", score);

    // Lo que GameOver mostrará como nuevo desbloqueo
    PlayerPrefs.SetString("NewUnlockedWord", unlockedWord);

    PlayerPrefs.Save();
}
}