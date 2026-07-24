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

    switch (currentMode)
    {
        case GameModeType.Normal:
            unlockedWord = TryUnlock(150, "UnlockedCaps", "caps");

            if (unlockedWord == "")
                unlockedWord = TryUnlock(100, "UnlockedMath", "calc");

            if (unlockedWord == "")
                unlockedWord = TryUnlock(50, "UnlockedReverse", "reverse");

            break;


        case GameModeType.Reverse:
            unlockedWord = TryUnlock(150, "UnlockedRandom", "random");

            if (unlockedWord == "")
                unlockedWord = TryUnlock(100, "UnlockedMath", "calc");

            if (unlockedWord == "")
                unlockedWord = TryUnlock(50, "UnlockedMissing", "missing");

            break;


        case GameModeType.Math:
            unlockedWord = TryUnlock(150, "UnlockedRandom", "random");

            if (unlockedWord == "")
                unlockedWord = TryUnlock(100, "UnlockedMissing", "missing");

            if (unlockedWord == "")
                unlockedWord = TryUnlock(50, "UnlockedCaps", "caps");

            break;


        case GameModeType.Caps:
            unlockedWord = TryUnlock(150, "UnlockedFlash", "flash");

            if (unlockedWord == "")
                unlockedWord = TryUnlock(100, "UnlockedRandom", "random");

            if (unlockedWord == "")
                unlockedWord = TryUnlock(50, "UnlockedMissing", "missing");

            break;


        case GameModeType.MissingLetters:
            unlockedWord = TryUnlock(100, "UnlockedFlash", "flash");

            if (unlockedWord == "")
                unlockedWord = TryUnlock(50, "UnlockedRandom", "random");

            break;


        case GameModeType.Random:
            unlockedWord = TryUnlock(
                75,
                "UnlockedFlash",
                "flash"
            );

            break;
    }

    PlayerPrefs.SetInt("Score", score);
    PlayerPrefs.SetString("NewUnlockedWord", unlockedWord);
    PlayerPrefs.Save();
}
private string TryUnlock(
    int requiredScore,
    string playerPrefsKey,
    string displayedWord)
{
    if (score < requiredScore)
        return "";

    // Ya estaba desbloqueada
    if (PlayerPrefs.GetInt(playerPrefsKey, 0) == 1)
        return "";

    PlayerPrefs.SetInt(playerPrefsKey, 1);

    return displayedWord;
}
}