using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersAPI.Data.Dtos;
using UsersAPI.Models;

namespace UsersAPI.Services;

public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;
    private SignInManager<User> _signInManager;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task Register(CreateUserDto dto)
    {
        User user = _mapper.Map<User>(dto);
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            throw new Exception("Failed to create user");
        }
    }

    public async Task Login(LoginUserDto dto)
    {
        var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

        if (!result.Succeeded)
        {
            throw new ApplicationException("User not authenticated");
        }
    }
}
