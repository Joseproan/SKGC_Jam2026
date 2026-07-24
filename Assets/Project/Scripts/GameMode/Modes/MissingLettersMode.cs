using UnityEngine;

public class MissingLettersMode : GameModeBase
{
    public override string GetDisplayedWord(string word)
    {
        char[] letters = word.ToCharArray();
        int hiddenLetters = Mathf.Max(1, word.Length / 3);

        for (int i = 0; i < hiddenLetters; i++)
        {
            int randomIndex = Random.Range(0, letters.Length);
            letters[randomIndex] = '_';
        }
        return new string(letters);
    }

    public override float GetTime()
    {
        return 15f;
    }
}