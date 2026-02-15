using System.Reflection.Metadata;

namespace BlazorApp1.Components.DB
{
    public class StoredData
    {
        public string[] answers = new string[9];
        public int guessesLeft  = 10;
        public bool infiniteGuesses = false;
        public bool UsedInfinite = false;
        public List<string>[] AllGivenAnswers = [.. new List<string>[9].Select(item => new List<string>())];
    }
}
