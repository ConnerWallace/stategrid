using System.Reflection.Metadata;

namespace BlazorApp1.Components.DB
{
    public class StoredData
    {
        public string[] answers { get; set; } = new string[9];
        public int guessesLeft { get; set; } = 10;
        public bool infiniteGuesses { get; set; } = false;
        public bool UsedInfinite { get; set; }  = false;
        public List<string>[] AllGivenAnswers { get; set; } = [.. new List<string>[9].Select(item => new List<string>())];
    }
}
