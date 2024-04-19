using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Dtos;
using UsersAPI.Services;

namespace UsersAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private UserService _userService;

    public UserController(UserService UserService)
    {
        _userService = UserService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(CreateUserDto dto)
    {
        await _userService.Register(dto);
        return Ok("User created successfully");
    }
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        var token = await _userService.Login(dto);

        return Ok(token);
    }
}
