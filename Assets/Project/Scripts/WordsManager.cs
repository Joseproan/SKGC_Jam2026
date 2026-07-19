using UnityEngine;
using TMPro;
public class WordsManager : MonoBehaviour
{
    private TextAsset dictionary;
    private string[] words;
    private string currentWord;
    private int score;
    private string difficulty;
    private float timer;
    private PaintColor paintColor;
    
    public TextMeshProUGUI wordDisplay;
    public TextMeshProUGUI downDisplay;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI timerDisplay;
    [SerializeField] private TMP_InputField inputField;

    private ScoreManager scoreManager;
    
    void Awake()
    {
        paintColor = this.GetComponent<PaintColor>();
        scoreManager = this.GetComponent<ScoreManager>();
    }
    void Start()
    {
        dictionary = Resources.Load<TextAsset>("words");
        NewRandomWord();

        scoreDisplay.text = (score).ToString();

        timer = 5.9f;
    }

  void Update()
{

        timerDisplay.text = ((int)timer).ToString();
        if (timer <= 0)
        {

        }
        else
        {
            timer -= Time.deltaTime;
        }
    
    if (inputField.text.Trim().ToLower() == currentWord.ToLower())
    {
        inputField.text = "";
        switch (difficulty)
        {
            case "easy":
                scoreManager.AddScore(1);
                break;
            case "medium":
                scoreManager.AddScore(3);
                break;
            case "hard":
                scoreManager.AddScore(6);
                break;
        }
        scoreDisplay.text = score.ToString();
        NewRandomWord();
        timer = 5.9f;
    }
}

    public void NewRandomWord()
    {
        words = dictionary.text.Split('\n');

        string randomWord = words[Random.Range(0, words.Length)].Trim();
        currentWord = randomWord;
        wordDisplay.text = paintColor.ColorWord(randomWord);
        downDisplay.text = new string('_', randomWord.Length);

        switch (randomWord.Length)
        {
            case <= 4:
            difficulty = "easy";
            break;
            case <= 9:
                difficulty = "medium";
                break;
            case > 9:
                difficulty = "hard";
                break;
        }
        inputField.Select();
        inputField.ActivateInputField();
    }




}
