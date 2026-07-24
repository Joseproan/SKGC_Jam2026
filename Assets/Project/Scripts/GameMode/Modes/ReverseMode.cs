using System;

public class ReverseMode : GameModeBase

{
        public override float GetTime()
    {
        return 10.9f;
    }
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
