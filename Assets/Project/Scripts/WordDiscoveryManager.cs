using UnityEngine;

public static class WordDiscoveryManager
{
    private const int RequiredScore = 50;

    public static string CheckDiscovery(GameModeType playedMode, int score)
    {
        if (score < RequiredScore)
            return "";

        switch (playedMode)
        {
            case GameModeType.Normal:
                return Discover(GameModeType.Reverse, "reverse");

            case GameModeType.Reverse:
                return Discover(GameModeType.MissingLetters, "missing");

            default:
                return "";
        }
    }

    private static string Discover(
        GameModeType mode,
        string displayedWord)
    {
        string key = GetKey(mode);

        // Ya se había descubierto antes
        if (PlayerPrefs.GetInt(key, 0) == 1)
            return "";

        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();

        return displayedWord;
    }

    public static bool IsDiscovered(GameModeType mode)
    {
        // Normal, representado por "play", siempre está descubierto
        if (mode == GameModeType.Normal)
            return true;

        return PlayerPrefs.GetInt(GetKey(mode), 0) == 1;
    }

    private static string GetKey(GameModeType mode)
    {
        return $"Discovered_{mode}";
    }
}