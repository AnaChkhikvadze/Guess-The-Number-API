using Microsoft.AspNetCore.Mvc;
using Guess_The_Number_API.Controllers;
using System;
using Guess_The_Number_API.Models;

namespace Guess_The_Number_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuessController : ControllerBase
    {
        [HttpPost]
        public ActionResult<GuessResponse> MakeGuess([FromBody] GuessRequest request)
        {
            if (request.LowerBound >= request.UpperBound)
            {
                return BadRequest("LowerBound must be less than UpperBound.");
            }

            int nextLowerBound = request.LowerBound;
            int nextUpperBound = request.UpperBound;

            if (request.PreviousResponse == ">")
            {
                nextUpperBound = request.PreviousGuess - 1;
                //nextUpperBound = nextLowerBound;
            }
            else if (request.PreviousResponse == "<")
            {
                nextLowerBound = request.PreviousGuess + 1;
            }
            else if (request.PreviousResponse == "=")
            {
                return new GuessResponse
                {
                    Guess = request.PreviousGuess,
                    Message = "Number Guessed!",
                    IsGuessed = true,
                    NextLowerBound = nextLowerBound,
                    NextUpperBound = nextUpperBound
                };
            }

            Random random = new Random();
            int guessNum = random.Next(nextLowerBound, nextUpperBound + 1);

            return new GuessResponse
            {
                Guess = guessNum,
                Message = $"Is your number {guessNum}? (Type >, <, or =)",
                IsGuessed = false,
                NextLowerBound = nextLowerBound,
                NextUpperBound = nextUpperBound
            };
        }
    }
}
