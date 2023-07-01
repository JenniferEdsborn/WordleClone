using WordleClone.Interfaces;

namespace WordleClone.Game
{
    public class WordleGameLogic : IWordleGameLogic
    {
        private readonly IWordCreator wordCreator;
        private readonly IWordChecker wordChecker;

        public WordleGameLogic(IWordChecker wordChecker, IWordCreator wordCreator)
        {
            this.wordChecker = wordChecker;
            this.wordCreator = wordCreator;
        }

        string GetMagicWord()
        {
            string magicWord = wordCreator.GetRandomWord();
            return magicWord;
        }

        public void PlayWordle(IConsoleIO io, IUser user)
        {
            string magicWord = GetMagicWord();

            io.PrintString("Just for testing purposes, the magic word is:" + magicWord);

            int guess = 1;
            string userGuess = "";

            while (guess <= 5 && userGuess != magicWord)
            {
                io.PrintPrompt($"Guess {guess}: ");
                userGuess = io.GetUserGuess();

                if (wordChecker.IsUserGuessCorrect(magicWord, userGuess))
                { 
                    WinGame(io, user, magicWord);
                }

                if (wordChecker.IsUserGuessCorrectFormat(userGuess)) 
                { 
                    guess++;
                    io.PrintString(wordChecker.BuildGuessFeedback(userGuess, magicWord));
                }
                else
                {
                    io.PrintString("Guess in incorrect format. Try again.");
                }

                if (!wordChecker.IsUserGuessCorrect(magicWord, userGuess) && guess > 5)
                {
                    LoseGame(io, user, magicWord);
                }
            }
        }

        void WinGame(IConsoleIO io, IUser user, string magicWord)
        {
            io.PrintString($"You win! The correct word was {magicWord.ToUpper()}!");
            user.WordsPlayed++;
            user.winsAndLosses["Wins"]++;
        }

        void LoseGame(IConsoleIO io, IUser user, string magicWord)
        {
            io.PrintString($"I'm sorry, the correct word was {magicWord.ToUpper()}!");
            user.WordsPlayed++;
            user.winsAndLosses["Losses"]++;
        }
    }
}
