using System;

public class ReverseMode : GameModeBase

{

    public override string GetDisplayedWord(string word)
    {
        char[] letters = word.ToCharArray();

        Array.Reverse(letters);

        return new string(letters);
    }

    public override int GetScore(string word)
    {
        return base.GetScore(word) * 2;
    }
}
