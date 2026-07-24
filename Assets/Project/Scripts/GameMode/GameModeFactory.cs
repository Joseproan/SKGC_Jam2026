using UnityEngine;

public static class GameModeFactory
{
    public static GameModeBase Create(GameModeType modeType)
    {
        return modeType switch
        {
            GameModeType.Reverse => new ReverseMode(),
            GameModeType.MissingLetters => new MissingLettersMode(),
            _ => new NormalMode()
        };
    }
}
