using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsersAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccessController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "MinimumAge")]
    public IActionResult Get()
    {
        return Ok("Access granted!");
    }
}
