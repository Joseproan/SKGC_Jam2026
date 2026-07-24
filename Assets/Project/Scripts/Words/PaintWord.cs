using UnityEngine;
using TMPro;

public class PaintWord : MonoBehaviour
{
    private TextMeshProUGUI wordText;

    private readonly string[] colors =
    {
        "#E76F51",
        "#E9B44C",
        "#55A7A1",
        "#9566C7",
        "#4F7DBD"
    };

    void Awake()
    {
        wordText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        PaintRandom();
    }

    public void PaintRandom()
    {
        string word = wordText.text;
        string coloredWord = "";

        foreach (char c in word)
        {
            string color = colors[Random.Range(0, colors.Length)];
            coloredWord += $"<color={color}>{c}</color>";
        }

        wordText.text = coloredWord;
    }
}