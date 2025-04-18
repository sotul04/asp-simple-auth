using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet("admin")]
    [Authorize(Roles = "ADMIN")]
    public IActionResult GetAdminData()
    {
        var userInfo = GetCurrentUserInfo();
        return Ok(new 
        {
            message = "Secret admin data",
            user = userInfo
        });
    }

    [HttpGet("user")]
    [Authorize(Roles = "USER")]
    public IActionResult GetUserData()
    {
        var userInfo = GetCurrentUserInfo();
        return Ok(new 
        {
            message = "Regular user data",
            user = userInfo
        });
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult GetMyInfo()
    {
        return Ok(GetCurrentUserInfo());
    }

    private object GetCurrentUserInfo()
    {
        return new
        {
            id = User.FindFirstValue(ClaimTypes.NameIdentifier),
            username = User.FindFirstValue(ClaimTypes.Name),
            role = User.FindFirstValue(ClaimTypes.Role),
            name = User.FindFirstValue(ClaimTypes.GivenName),
            email = User.FindFirstValue(ClaimTypes.Email)
        };
    }
}