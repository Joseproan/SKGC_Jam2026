using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeSelector : MonoBehaviour
{
    public void SelectNormal()
    {
        StartGame(GameModeType.Normal);
    }

    public void SelectReverse()
    {
        StartGame(GameModeType.Reverse);
    }

    public void SelectMissingLetters()
    {
        StartGame(GameModeType.MissingLetters);
    }

    private void StartGame(GameModeType mode)
    {
        PlayerPrefs.SetInt("GameMode", (int)mode);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Game");
    }
}