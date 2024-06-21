namespace Guess_The_Number_API.Models
{
    public class GuessResponse
    {
        public int Guess { get; set; }
        public string? Message { get; set; } = null;
        public bool IsGuessed { get; set; }
    }
}
