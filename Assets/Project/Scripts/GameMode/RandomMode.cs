using UnityEngine;

public class RandomMode : GameModeBase
{
    private GameModeBase selectedMode;

    public override string GetDisplayedWord(string word)
    {
        int randomMode = Random.Range(0, 3);

        selectedMode = randomMode switch
        {
            0 => new NormalMode(),
            1 => new ReverseMode(),
            _ => new MissingLettersMode()
        };

        return selectedMode.GetDisplayedWord(word);
    }

    public override bool IsCorrect(string input, string realWord)
    {
        return selectedMode.IsCorrect(input, realWord);
    }

    public override float GetTime()
    {
        return 5.9f;
    }

    public override int GetScore(string word)
    {
        return selectedMode.GetScore(word);
    }
}