using UnityEngine;

public class PaintColor : MonoBehaviour
{
    public string ColorWord(string word)
    {
        string coloredWord = "";

        for (int i = 0; i < word.Length; i++)
        {
            string color = colors[i % colors.Length];
            coloredWord += $"<color={color}>{word[i]}</color>";

        }
        return coloredWord;
    }

    private readonly string[] colors = {

        "#E76F51",

        "#E9B44C",

        "#55A7A1",

        "#9566C7",

        "#4F7DBD"
    };
}
