using UnityEngine;

public class CapsMode : GameModeBase
{
    private string displayedWord;

    public override string GetDisplayedWord(string word)
    {
        char[] letters = word.ToCharArray();

        for (int i = 0; i < letters.Length; i++)
        {
            letters[i] = Random.value < 0.5f
                ? char.ToUpper(letters[i])
                : char.ToLower(letters[i]);
        }

        displayedWord = new string(letters);

        return displayedWord;
    }

    public override bool IsCorrect(string input, string realWord)
    {
        return input.Trim() == displayedWord;
    }

    public override float GetTime()
    {
        return 6f;
    }

    public override int GetScore(string word)
    {
        return base.GetScore(word) + 2;
    }
}