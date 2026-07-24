using TMPro;
using UnityEngine;

public class WordGuideSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wordText;

    public void Setup(string word, bool discovered)
    {
        wordText.text = discovered ? word : "?";
    }
}