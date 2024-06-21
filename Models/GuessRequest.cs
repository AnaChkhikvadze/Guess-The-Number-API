namespace Guess_The_Number_API.Models
{
    public class GuessRequest
    {
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }
        public String? PreviousResponse { get; set; } = null;
        public int PreviousGuess { get; set; } 
    }
}
