public class FlashMode : GameModeBase
{
    public override string GetDisplayedWord(string word)
    {
        return word;
    }

    public override bool IsCorrect(string input, string realWord)
    {
        return input.Trim().ToLower() == realWord.ToLower();
    }

    public override float GetTime()
    {
        return 5f;
    }

    public override int GetScore(string word)
    {
        return base.GetScore(word) + 6;
    }

    public float VisibleTime => 1f;
}