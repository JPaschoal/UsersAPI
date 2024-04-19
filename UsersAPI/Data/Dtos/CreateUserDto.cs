using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Data.Dtos;

public class CreateUserDto
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
