using WordleClone.Game;
using WordleClone.Interfaces;
using WordleClone.Utilities;

// Load User Data here

IConsoleIO io = new ConsoleIO();

IWordChecker wordChecker = new WordChecker();
IWordCreator wordCreator = new WordCreator();
IWordleGameLogic gameLogic = new WordleGameLogic(wordChecker, wordCreator);

IUser user = new User("", 0);
IGameMenu gameMenu = new GameMenu(io, user, gameLogic);

GameController game = new GameController(io, gameMenu, user);

game.Start();

