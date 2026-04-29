using System.Reflection.Metadata;

namespace BlazorApp1.Components.DB
{
    public class StoredData
    {
        public string[] Answers { get; set; } = new string[9];
        public int GuessesLeft { get; set; } = 10;
        public bool InfiniteGuesses { get; set; } = false;
        public bool UsedInfinite { get; set; }  = false;
        public List<string>[] AllGivenAnswers { get; set; } = [.. new List<string>[9].Select(item => new List<string>())];
        public List<string>[] AllWrongGuesses { get; set; } = [.. new List<string>[9].Select(item => new List<string>())];
    }
}
