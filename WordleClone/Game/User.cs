using WordleClone.Interfaces;

namespace WordleClone.Game
{
    public class User : IUser
    {
        public string Name { get; set; }
        public Dictionary<string, int> winsAndLosses { get; set; }
        public int WordsPlayed { get; set; }

        public User(string name, int wordsPlayed)
        {
            Name = name;
            WordsPlayed = wordsPlayed;
            winsAndLosses = new Dictionary<string, int>();
            InstantiateDictionary();
        }

        private void InstantiateDictionary()
        {
            winsAndLosses.Add("Wins", 0);
            winsAndLosses.Add("Losses", 0);
        }
    }
}
