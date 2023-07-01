using WordleClone.Interfaces;

namespace WordleClone.Utilities
{
    public class WordCreator : IWordCreator
    {
        private List<string> words = new List<string>();
        private Random rnd = new Random();

        public string GetRandomWord()
        {
            string randomWord = "";

            if (words.Count  == 0)
            {
                PopulateWordList();
            }
            
            int index = rnd.Next(0, words.Count);
            randomWord = words[index];

            words.RemoveAt(index);

            return randomWord;
        }

        private void PopulateWordList()
        {
            string[] wordsArray = {
                "lucky", "jolly", "fairy", "crown", "lungs", "bumpy", "spark", "flute", "beard", "frost",
                "risky", "punch", "wreck", "bloom", "coast", "feast", "squad", "smile", "oasis", "fancy",
                "brush", "lemon", "beast", "haste", "scary", "globe", "vivid", "proud", "flask", "vocal",
                "rider", "noble", "tutor", "couch", "virus", "blade", "crisp", "sweep", "fluid", "fable",
                "token", "graze", "bonus", "quake", "cabin", "pride", "badge", "scone", "chill", "spark",
                "party", "pouch", "trick", "prize", "creek", "sooth", "savor", "ocean", "asset", "angel",
                "wagon", "flick", "decal", "snore", "charm", "proud", "grain", "tasty", "greet", "glory",
                "sweep", "witty", "still", "genre", "smash", "stall", "prize", "jelly", "grace", "spoon",
                "black", "swirl", "frost", "diner", "laser", "greet", "bless", "bound", "feast", "grace",
                "slice", "wreck", "swift", "jolly", "crown", "dream", "blend", "globe", "shout", "mirth"
            };

            foreach (string word in wordsArray)
            {
                words.Add(word);
            }
        }
    }
}
