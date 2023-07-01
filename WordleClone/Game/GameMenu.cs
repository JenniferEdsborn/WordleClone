using WordleClone.Interfaces;

namespace WordleClone.Game
{
    public class GameMenu : IGameMenu
    {
        private readonly IConsoleIO io;
        private readonly IUser user;
        private readonly IWordleGameLogic gameLogic;

        public GameMenu(IConsoleIO io, IUser user, IWordleGameLogic gameLogic)
        {
            this.io = io;
            this.user = user;
            this.gameLogic = gameLogic;
        }

        string[] Menu()
        {
            string[] menu = { "Play", "Score", "Help", "Exit" };
            return menu;
        }

        string[] Instructions()
        {
            string[] instructions = { "Instructions", "1. Your guess must be five characters long, no special characters or white spaces.",
            "2. For each wrong letter, - is displayed. For right letter in the wrong place, * is displayed.",
            "3. For example, if the answer is \"APPLE\" and you input \"PEARL\", the output would be \"P**R-\".",
            "Good luck!"};
            return instructions;
        }

        public void Play()
        {
            gameLogic.PlayWordle(io, user);
        }

        public void Score()
        {
            io.PrintString($"User {user.Name}'s stats:");
            io.PrintString($"Games played: {user.WordsPlayed}");

            foreach (var entry in user.winsAndLosses)
            {
                io.PrintString($"{entry.Key}: {entry.Value}");
            }
        }

        public void Help()
        {
            string[] instructions = Instructions();

            for (int i = 0; i < instructions.Length; i++)
            {
                io.PrintString(instructions[i]);
            }
        }

        public void Welcome()
        {
            io.PrintString("\n- - - - - - WordleClone - - - - - -");
            io.PrintString($"Welcome, {user.Name}.");
            io.PrintString("\n - - Menu");
        }

        public void PrintMenuChoices()
        {
            string[] menu = Menu();

            io.PrintString("");

            for (int i = 0; i < menu.Length; i++)
            {
                io.PrintString((i + 1) + ". " + menu[i]);
            }
        }

        public void PrintInstructions()
        {
            string[] instructions = Instructions();

            foreach (string instruction in instructions)
            {
                io.PrintString(instruction);
            }
        }
    }
}
