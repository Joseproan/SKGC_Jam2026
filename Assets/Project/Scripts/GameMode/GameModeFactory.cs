public static class GameModeFactory
{
    public static GameModeBase Create(GameModeType modeType)
    {
        return modeType switch
        {
            GameModeType.Reverse => new ReverseMode(),
            GameModeType.MissingLetters => new MissingLettersMode(),
            GameModeType.Math => new MathMode(),
            GameModeType.Caps => new CapsMode(),
            GameModeType.Flash => new FlashMode(),
            GameModeType.Random => new RandomMode(),
            _ => new NormalMode(),

        };
    }
}