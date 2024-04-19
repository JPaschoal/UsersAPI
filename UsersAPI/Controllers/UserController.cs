using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Dtos;
using UsersAPI.Models;
using UsersAPI.Services;

namespace UsersAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private AddUserService _addUserService;

    public UserController(AddUserService addUserService)
    {
        _addUserService = addUserService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(CreateUserDto dto)
    {
        await _addUserService.Add(dto);
        return Ok("User created successfully");
    }
}
