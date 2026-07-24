using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    private Animator wordAnim;
    public TextMeshProUGUI downDisplay;
    public TextMeshProUGUI timerDisplay;
    public Image timerSlider;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI inputFieldText;
    [SerializeField] private Animator bubbleEffect;

    private bool wordCompleted;
    [SerializeField] private float timeAfterCompletion = 0.5f;
    private float completionTimer;

    private ScoreManager scoreManager;
    private GameModeBase currentGameMode;
    private const float DefaultTime = 5.9f;
    private GameModeType selectedMode;

    void Awake()
    {
        paintColor = this.GetComponent<PaintColor>();
        scoreManager = this.GetComponent<ScoreManager>();
        wordAnim = wordDisplay.GetComponent<Animator>();
    }
void Start()
{
    dictionary = Resources.Load<TextAsset>("words");
    words = dictionary.text.Split('\n');
    
    
    selectedMode = (GameModeType)PlayerPrefs.GetInt("GameMode");

    currentGameMode = GameModeFactory.Create(selectedMode);

    NewRandomWord();
}

 private void Update()
{
    UpdateTimer();

    if (!wordCompleted &&
        currentGameMode.IsCorrect(inputField.text, currentWord))
    {
        CompleteWord();
    }

    if (wordCompleted)
    {
        UpdateCompletion();
    }
}
private void CompleteWord()
{
    inputFieldText.color = Color.green;
    AudioManager.Instance.PlaySFX("UI", "Pop");

    inputField.DeactivateInputField();

    wordAnim.SetTrigger("Completed");

    wordCompleted = true;

    int points = currentGameMode.GetScore(currentWord);

    scoreManager.AddScore(points);
}
private void NewRandomWord()
{
    inputFieldText.color = Color.black;
    currentWord = words[Random.Range(0, words.Length)].Trim();

    string displayedWord =
        currentGameMode.GetDisplayedWord(currentWord);

    wordDisplay.text =
        paintColor.ColorWord(displayedWord);

    downDisplay.text =
        new string('-', currentWord.Length);

    timer = currentGameMode.GetTime();

    inputField.text = "";
    inputField.Select();
    inputField.ActivateInputField();
}


private void UpdateTimer()
{
    timerDisplay.text = Mathf.CeilToInt(timer).ToString();
    timerSlider.fillAmount = timer / currentGameMode.GetTime();

    if (wordCompleted)
        return;

    timer -= Time.deltaTime;

    if (timer <= 0)
    {
        scoreManager.SaveScore();
        SceneManager.LoadScene("GameOver");
    }
}

private void UpdateCompletion()
{
    completionTimer += Time.deltaTime;

    if (completionTimer < timeAfterCompletion)
        return;

    wordCompleted = false;
    completionTimer = 0f;

    NewRandomWord();
}

}
