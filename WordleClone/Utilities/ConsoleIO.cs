using WordleClone.Interfaces;

namespace WordleClone.Utilities
{
    public class ConsoleIO : IConsoleIO
    {
        public void PrintString(string output)
        {
            Console.WriteLine(output);
        }

        public void PrintPrompt(string output)
        {
            Console.Write(output);
        }

        public string GetUserString()
        {
            return Console.ReadLine();
        }

        public string GetUserGuess()
        {
            // check input 5 chars
            // check input correct (no numbers or special characters)

            return Console.ReadLine();
        }

        public bool IsNumber(string userInput)
        {
            return Int32.TryParse(userInput, out _);
        }

        public int ConvertToInt(string userInput)
        {
            return Convert.ToInt32(userInput);
        }

        public void PressAnyKey()
        {
            Console.ReadKey();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
