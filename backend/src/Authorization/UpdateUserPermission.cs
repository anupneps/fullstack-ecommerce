using backend.src.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace backend.src.Authorization
{
    public class UpdateUserRequirement : IAuthorizationRequirement { }

    public class UpdateUserHandler : AuthorizationHandler<UpdateUserRequirement, int>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            UpdateUserRequirement requirement, int resource)

        {
            var userRole = context.User.FindFirstValue(ClaimTypes.Role);
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userRole == Role.admin.ToString())
            {
                context.Succeed(requirement);
            }
            else if (userId == resource.ToString())
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
