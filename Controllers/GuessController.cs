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

            int lower = request.LowerBound;
            int upper = request.UpperBound;

            if (request.PreviousResponse == ">")
            {
                upper = request.PreviousGuess - 1;
            }
            else if (request.PreviousResponse == "<")
            {
                lower = request.PreviousGuess + 1;
            }
            else if (request.PreviousResponse == "=")
            {
                return new GuessResponse
                {
                    Guess = request.PreviousGuess,
                    Message = "Number Guessed!",
                    IsGuessed = true
                };
            }
            int guessNum = (lower + upper) / 2;

            return new GuessResponse
            {
                Guess = guessNum,
                Message = $"Is your number {guessNum}? (Type >, <, or =)",
                IsGuessed = false
            };
        }
    }
}
