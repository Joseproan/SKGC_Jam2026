using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WordsGuideManager : MonoBehaviour
{
        [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI reverseText;
    [SerializeField] private TextMeshProUGUI missingText;

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
                

            }
            }
}