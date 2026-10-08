using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace bdoProject.Api.Extensions.Auth;

public static class UserExtensions
{
    public static string GetUserId(this ControllerBase controller)
    {
        var userIdClaim = controller.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim))
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        return userIdClaim;
    }
}