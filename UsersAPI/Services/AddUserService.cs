using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersAPI.Data.Dtos;
using UsersAPI.Models;

namespace UsersAPI.Services;

public class AddUserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public AddUserService(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task Add(CreateUserDto dto)
    {
        User user = _mapper.Map<User>(dto);
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            throw new Exception("Failed to create user");
        }
    }
}
