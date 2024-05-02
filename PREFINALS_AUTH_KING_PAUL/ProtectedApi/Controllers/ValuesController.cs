using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        var userClaims = User.Claims.Select(c => new { c.Type, c.Value });
        // Return user information and fun facts about API creator
        return Ok(new
        {
            User = new { Name = "Paul", Section = "BSCS-32E1", Course = "ComSci" },
            FunFacts = new string[]
            {
                "I love coding!",
                "I enjoy gaming.",
                "I'm a tech enthusiast."
            }
        });
    }
}
