using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI failedWordText;

    [Header("Nueva palabra")]
    [SerializeField] private GameObject newWordSection;
    [SerializeField] private TextMeshProUGUI newWordText;

private void Start()

{

    FocusInput();

    inputField.onValueChanged.AddListener(CheckCommand);

    scoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();

    failedWordText.text = PlayerPrefs.GetString("FailedWord", "");

    ShowUnlockedWord();

}
    void Update()
    {
    if (!inputField.isFocused)

    {

        FocusInput();

    }
    }

private void FocusInput()
{
    inputField.Select();
    inputField.ActivateInputField();

    int endPosition = inputField.text.Length;

    inputField.caretPosition = endPosition;
    inputField.selectionAnchorPosition = endPosition;
    inputField.selectionFocusPosition = endPosition;
}
    private void ShowUnlockedWord()
    {
        string unlockedWord =
            PlayerPrefs.GetString("NewUnlockedWord", "");

        bool unlockedSomething =
            unlockedWord != "";

        newWordSection.SetActive(unlockedSomething);

        if (unlockedSomething)
        {
            newWordText.text = unlockedWord;
        }
    }

    private void OnDestroy()
    {
        inputField.onValueChanged.RemoveListener(CheckCommand);
    }

    private void CheckCommand(string text)
    {
        switch (text.Trim().ToLower())
        {
            case "menu":
                SceneManager.LoadScene("Menu");
                break;

            case "play":
                PlayerPrefs.SetInt(
                    "GameMode",
                    (int)GameModeType.Normal
                );

                SceneManager.LoadScene("Game");
                break;
            
                case "reverse":
                PlayerPrefs.SetInt(
                    "GameMode",
                    (int)GameModeType.Reverse
                );

                SceneManager.LoadScene("Game");
                break;

            case "words":
                SceneManager.LoadScene("Words");
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