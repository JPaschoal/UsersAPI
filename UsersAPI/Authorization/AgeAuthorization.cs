using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace UsersAPI.Authorization;

public class AgeAuthorization : AuthorizationHandler<MinimumAgeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        var dataOfBirthClaim = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);

        if (dataOfBirthClaim == null) return Task.CompletedTask;

        var dateOfBirth = Convert.ToDateTime(dataOfBirthClaim.Value);
        var age = DateTime.Today.Year - dateOfBirth.Year;

        if (dateOfBirth.Date > DateTime.Today.AddYears(-age))
            age--;

        if (age >= requirement.MinimumAge)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
