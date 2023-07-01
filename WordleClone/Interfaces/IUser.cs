namespace WordleClone.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        Dictionary<string, int> winsAndLosses { get; set; }
        int WordsPlayed { get; set; }
    }
}
