using System.Text;
using WordleClone.Interfaces;

namespace WordleClone.Utilities
{
    public class WordChecker : IWordChecker
    {
        public bool IsUserGuessCorrect(string magicWord, string userGuess)
        {
            return magicWord.ToUpper() == userGuess.ToUpper();
        }

        public bool IsUserGuessCorrectFormat(string userGuess)
        {
            return userGuess.Length == 5 && CheckUserGuess(userGuess);
        }

        private bool CheckUserGuess(string userGuess)
        {
            return userGuess.All(Char.IsLetter);
        }

        private Dictionary<char, int> CountLettersInWord(string word)
        {
            var charCount = new Dictionary<char, int>();

            foreach (char c in word)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }

            return charCount;
        }

        public string BuildGuessFeedback(string userGuess, string magicWord)
        {
            StringBuilder guessFeedback = new StringBuilder(new String('-', userGuess.Length));
            Dictionary<char, int> magicWordCharCount = CountLettersInWord(magicWord.ToUpper());

            userGuess = userGuess.ToUpper();
            magicWord = magicWord.ToUpper();

            MarkCorrectlyPlacedLetters(guessFeedback, magicWordCharCount, userGuess, magicWord);
            MarkMisplacedLetters(guessFeedback, magicWordCharCount, userGuess);

            return guessFeedback.ToString();
        }

        private void MarkCorrectlyPlacedLetters(StringBuilder guessFeedback, Dictionary<char, int> magicWordCharCount, string userGuess, string magicWord)
        {
            for (int i = 0; i < userGuess.Length; i++)
            {
                if (userGuess[i] == magicWord[i])
                {
                    guessFeedback[i] = userGuess[i];
                    magicWordCharCount[userGuess[i]]--;
                }
            }
        }

        private void MarkMisplacedLetters(StringBuilder guessFeedback, Dictionary<char, int> magicWordCharCount, string userGuess)
        {
            for (int i = 0; i < userGuess.Length; i++)
            {
                if (guessFeedback[i] == '-' && magicWordCharCount.ContainsKey(userGuess[i]) && magicWordCharCount[userGuess[i]] > 0)
                {
                    guessFeedback[i] = '*';
                    magicWordCharCount[userGuess[i]]--;
                }
            }
        }
    }
}
