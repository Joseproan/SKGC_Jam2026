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
    private string failedWord;
    private float currentMaxTime;
    private string currentChallenge;

    private bool flashHidden;

    [SerializeField] private TextMeshProUGUI modeTitle;
private float flashTimer;

    void Awake()
    {
        paintColor = this.GetComponent<PaintColor>();
        scoreManager = this.GetComponent<ScoreManager>();
        wordAnim = wordDisplay.GetComponent<Animator>();
    }
void Start()
{
    FocusInput();
    dictionary = Resources.Load<TextAsset>("words");
    words = dictionary.text.Split('\n');
    
    
    selectedMode = (GameModeType)PlayerPrefs.GetInt("GameMode");

    currentGameMode = GameModeFactory.Create(selectedMode);

    UpdateModeTitle();

    NewRandomWord();
}
private void UpdateModeTitle()
{
    modeTitle.text = selectedMode switch
    {
        GameModeType.Normal => "COPY",
        GameModeType.Reverse => "REVERSE",
        GameModeType.MissingLetters => "MISSING",
        GameModeType.Math => "CALC",
        GameModeType.Random => "RANDOM",
        GameModeType.Caps => "CAPS",
        GameModeType.Flash => "FLASH",
        _ => "COPY"
    };
}
 private void Update()
{
        if (!inputField.isFocused)

    {

        FocusInput();

    }
    UpdateTimer();
    UpdateFlashMode();

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

private void FocusInput()
{
    inputField.Select();
    inputField.ActivateInputField();

    int endPosition = inputField.text.Length;

    inputField.caretPosition = endPosition;
    inputField.selectionAnchorPosition = endPosition;
    inputField.selectionFocusPosition = endPosition;
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

    currentWord =
        words[Random.Range(0, words.Length)].Trim();

    currentChallenge =
        currentGameMode.GetDisplayedWord(currentWord);

    wordDisplay.text =
        paintColor.ColorWord(currentChallenge);

        if (currentGameMode is FlashMode flashMode)
{
    flashHidden = false;
    flashTimer = flashMode.VisibleTime;
}

    if (selectedMode == GameModeType.Math)
    {
        downDisplay.text = "";
    }
    else
    {
        downDisplay.text =
            new string('-', currentWord.Length);
    }

    currentMaxTime = CalculateWordTime();
    timer = currentMaxTime;

    inputField.text = "";
    inputField.Select();
    inputField.ActivateInputField();
}


private void UpdateTimer()
{
    timerDisplay.text = Mathf.CeilToInt(timer).ToString();
timerSlider.fillAmount = timer / currentMaxTime;

    if (wordCompleted)
        return;

    timer -= Time.deltaTime;

    if (timer <= 0)
    {
        failedWord = currentChallenge;
        PlayerPrefs.SetString("FailedWord", failedWord);
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

private float CalculateWordTime()
{
    float baseTime = currentGameMode.GetTime();

    int score = scoreManager.GetScore();

    // Cada 30 puntos aumenta un nivel de velocidad
    int speedLevel = score / 20;

    // Cada nivel deja el tiempo en un 90% del anterior
    float reducedTime =
        baseTime * Mathf.Pow(0.9f, speedLevel);

    return Mathf.Max(reducedTime, 1.5f);
}

private void UpdateFlashMode()
{
    if (!(currentGameMode is FlashMode))
        return;

    if (flashHidden)
        return;

    flashTimer -= Time.deltaTime;

    if (flashTimer <= 0)
    {
        flashHidden = true;

        wordDisplay.text =
            new string('-', currentWord.Length);
    }
}

}
