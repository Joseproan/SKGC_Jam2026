using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WordsGuideManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI reverseText;
    [SerializeField] private TextMeshProUGUI missingText;
    [SerializeField] private TextMeshProUGUI mathText;
    [SerializeField] private TextMeshProUGUI randomText;
    [SerializeField] private TextMeshProUGUI capsText;
    [SerializeField] private TextMeshProUGUI flashText;

    private void Start()
    {
        inputField.Select();
        inputField.ActivateInputField();

        inputField.onValueChanged.AddListener(CheckCommand);

        reverseText.text =
            PlayerPrefs.GetInt("UnlockedReverse", 0) == 1
                ? "reverse"
                : "?";

        missingText.text =
            PlayerPrefs.GetInt("UnlockedMissing", 0) == 1
                ? "missing"
                : "?";
        mathText.text = PlayerPrefs.GetInt("UnlockedMath", 0) == 1
                ? "calc"
                : "?";

                randomText.text =
    PlayerPrefs.GetInt("UnlockedRandom", 0) == 1
        ? "random"
        : "?";

        capsText.text =
    PlayerPrefs.GetInt("UnlockedCaps", 0) == 1
        ? "caps"
        : "?";

        flashText.text =
    PlayerPrefs.GetInt("UnlockedFlash", 0) == 1
        ? "flash"
        : "?";
    }

    private void OnDestroy()
    {
        inputField.onValueChanged.RemoveListener(CheckCommand);
    }

    private void CheckCommand(string text)
    {
        switch (text.Trim().ToLower())
        {
            case "mute":
                AudioManager.mute = !AudioManager.mute;
                inputField.text = "";
                break;

            case "play":
                PlayerPrefs.SetInt("GameMode", (int)GameModeType.Normal);
                SceneManager.LoadScene("Game");
                break;
            case "words":
                PlayerPrefs.SetInt("GameMode", (int)GameModeType.MissingLetters);
                SceneManager.LoadScene("Words");
                break;

            case "reverse":
                PlayerPrefs.SetInt("GameMode", (int)GameModeType.Reverse);
                SceneManager.LoadScene("Game");
                break;

            case "missing":
                PlayerPrefs.SetInt("GameMode", (int)GameModeType.MissingLetters);
                SceneManager.LoadScene("Game");
                break;
            case "calc":
                PlayerPrefs.SetInt(
                    "GameMode",
                    (int)GameModeType.Math
                );

                SceneManager.LoadScene("Game");
                break;

                            case "random":
                PlayerPrefs.SetInt(
                    "GameMode",
                    (int)GameModeType.Random
                );

                SceneManager.LoadScene("Game");
                break;

                case "caps":
                PlayerPrefs.SetInt("GameMode", (int)GameModeType.Caps);
                SceneManager.LoadScene("Game");
                break;

                case "flash":
                PlayerPrefs.SetInt("GameMode", (int)GameModeType.Flash);
                SceneManager.LoadScene("Game");
                break;
                

        }
    }
}