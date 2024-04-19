using Microsoft.AspNetCore.Identity;

namespace UsersAPI.Models;

public class User : IdentityUser
{
    public DateTime BirthdayDate { get; set; }

    public User() : base() { }
}
