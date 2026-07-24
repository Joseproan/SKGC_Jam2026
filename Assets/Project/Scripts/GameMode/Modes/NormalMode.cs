using UnityEngine;

public class NormalMode : GameModeBase
{
    public override string GetDisplayedWord(string word)
    {
        return word;
    }

        public override float GetTime()
    {
        return 5.9f;
    }
}
