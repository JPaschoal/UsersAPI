using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Dtos;

namespace UsersAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult AddUser(CreateUserDto user)
    {
        throw new NotImplementedException();
    }
}
