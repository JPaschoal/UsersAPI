using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Dtos;
using UsersAPI.Models;

namespace UsersAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public UserController(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(CreateUserDto dto)
    {
        User user = _mapper.Map<User>(dto);
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        if (result.Succeeded) return Ok("User created successfully");

        throw new Exception("Failed to create user");
    }
}
