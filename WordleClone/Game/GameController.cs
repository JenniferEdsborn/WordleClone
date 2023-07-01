using WordleClone.Interfaces;

namespace WordleClone.Game
{
    public class GameController
    {
        private readonly IConsoleIO io;
        private readonly IGameMenu menu;
        private readonly IUser user;

        public GameController(IConsoleIO io, IGameMenu menu, IUser user)
        {
            this.io = io;
            this.menu = menu;
            this.user = user;
        }

        public void Start()
        {
            // own method, create user or load user - stored in json-files, name and scores"
            if (user.Name == "")
            {
                io.PrintPrompt("User name: ");
                user.Name = io.GetUserString();

                menu.Welcome();
            }

            GetMenuChoice();
        }

        private void GetMenuChoice()
        {
            while (true)
            {
                menu.PrintMenuChoices();

                string userChoiceString = io.GetUserString();

                if (io.IsNumber(userChoiceString))
                {
                    int userChoiceInt = io.ConvertToInt(userChoiceString);
                    DisplayMenu(userChoiceInt);
                }
                else
                {
                    io.PrintString("Input is not in the accepted format.");
                    GetMenuChoice();
                }
            }
        }

        public void DisplayMenu(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    menu.Play();
                    break;
                case 2:
                    menu.Score();
                    break;
                case 3:
                    menu.Help();
                    break;
                case 4:
                    io.Exit();
                    break;
                default:
                    io.PrintString("Invalid choice.");
                    break;
            }
        }
    }
}
