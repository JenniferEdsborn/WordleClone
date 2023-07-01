namespace WordleClone.Interfaces
{
    public interface IConsoleIO
    {
        void Clear();
        void Exit();
        string GetUserString();
        string GetUserGuess();
        void PressAnyKey();
        void PrintPrompt(string output);
        void PrintString(string output);
        bool IsNumber(string userInput);
        int ConvertToInt(string userInput);
    }
}
