using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputField.Select();
        inputField.ActivateInputField();

        inputField.onValueChanged.AddListener(CheckCommand);
    }

    private void OnDestroy()
    {
        inputField.onValueChanged.RemoveListener(CheckCommand);
    }
    // Update is called once per frame
    void Update()
    {
        
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

