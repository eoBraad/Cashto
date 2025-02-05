using System.Security.Claims;
using Cashto.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Cashto.Api.Authorization;

public class OwnerRequirement : IAuthorizationRequirement { }

public class OwnerAuthorizationHandler : AuthorizationHandler<OwnerRequirement, Account>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        OwnerRequirement requirement,
        Account resource)
    {
        var userId = context.User.FindFirst(ClaimTypes.Sid)?.Value;
        if (userId != null && resource.UserId.ToString() == userId)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}