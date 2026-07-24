using UnityEngine;

public class MathMode : GameModeBase
{
    private int correctResult;

    public override string GetDisplayedWord(string word)
    {
        return GenerateOperation();
    }

    public override bool IsCorrect(string input, string realWord)
    {
        return input.Trim() == correctResult.ToString();
    }

    public override float GetTime()
    {
        return 7f;
    }

    public override int GetScore(string word)
    {
        return 3;
    }

    private string GenerateOperation()
    {
        int operationType = Random.Range(0, 4);

        int numberA;
        int numberB;

        switch (operationType)
        {
            case 0:
                // Suma
                numberA = Random.Range(1, 21);
                numberB = Random.Range(1, 21);

                correctResult = numberA + numberB;

                return $"{numberA} + {numberB}";

            case 1:
                // Resta sin resultados negativos
                numberA = Random.Range(5, 31);
                numberB = Random.Range(1, numberA + 1);

                correctResult = numberA - numberB;

                return $"{numberA} - {numberB}";

            case 2:
                // Multiplicación sencilla
                numberA = Random.Range(2, 11);
                numberB = Random.Range(2, 11);

                correctResult = numberA * numberB;

                return $"{numberA} × {numberB}";

            default:
                // División siempre exacta
                numberB = Random.Range(2, 11);
                correctResult = Random.Range(2, 11);

                numberA = numberB * correctResult;

                return $"{numberA} ÷ {numberB}";
        }
    }
}