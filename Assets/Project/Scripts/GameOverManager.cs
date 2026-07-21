using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputField.Select();
        inputField.ActivateInputField();
        GetScore();

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

    private void GetScore()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }
        private void CheckCommand(string text)
        {
            switch (text.Trim().ToLower())
            {
                case "menu":
                    SceneManager.LoadScene("Menu");
                    break;

                case "play":
                    SceneManager.LoadScene("Game");
                    break;

                case "scores":
                    SceneManager.LoadScene("Scores");
                    break;
            }
    }
}
