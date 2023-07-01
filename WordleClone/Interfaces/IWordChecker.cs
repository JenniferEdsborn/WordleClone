namespace WordleClone.Interfaces
{
    public interface IWordChecker
    {
        string BuildGuessFeedback(string userGuess, string magicWord);
        bool IsUserGuessCorrect(string magicWord, string userGuess);
        bool IsUserGuessCorrectFormat(string userGuess);
    }
}
