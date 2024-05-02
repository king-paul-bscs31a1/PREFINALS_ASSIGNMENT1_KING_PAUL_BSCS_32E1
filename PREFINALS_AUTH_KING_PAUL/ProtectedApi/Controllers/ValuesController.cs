using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ProtectedApi
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private static readonly Random random = new Random();
        private readonly string ownerName = "Paul Edrel B. King"; // Replace with actual owner name

        [HttpGet("about/me")]
        public IActionResult GetAboutMe()
        {
            List<string> randomFacts = new List<string>
            {
                "I love coding!",
                "I enjoy gaming.",
                "I'm a tech enthusiast.",
                // Add more random facts here
            };

            int randomIndex = random.Next(randomFacts.Count);
            string randomFact = randomFacts[randomIndex];

            var aboutMeResponse = new
            {
                Fact = randomFact
            };

            return Ok(aboutMeResponse);
        }

        [HttpGet("about")]
        public IActionResult GetAbout()
        {
            var aboutResponse = new
            {
                Owner = ownerName
            };

            return Ok(aboutResponse);
        }

        [HttpPost("about")]
        public IActionResult PostAbout([FromBody] NameRequest nameRequest)
        {
            string name = nameRequest.Name;
            var hiMessage = $"Hi {name} from {ownerName}";

            var postAboutResponse = new
            {
                Message = hiMessage
            };

            return Ok(postAboutResponse);
        }
    }

    public class NameRequest
    {
        public string Name { get; set; }
    }
}
