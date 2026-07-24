using UnityEngine;

public abstract class GameModeBase
{
    public abstract string GetDisplayedWord(string word);

    public virtual bool IsCorrect(string input, string realWord)
    {
        return input.Trim().ToLower() == realWord.ToLower();
    }

    public virtual float GetTime()
    {
        return 5.9f;
    }

    public virtual int GetScore(string word)
    {
        return word.Length switch
        {
            <= 4 => 1,
            <= 9 => 3,
            _ => 6
        };
    }
}