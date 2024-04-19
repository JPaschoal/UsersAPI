using System.ComponentModel.DataAnnotations;

namespace UsersAPI;

public class LoginUserDto
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
