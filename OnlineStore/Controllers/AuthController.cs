using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Services;
using OnlineStore.Shared.DTOs;
using OnlineStore.Shared.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;

namespace OnlineStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserServices _userService;
    private readonly IConfiguration _configuration;

    public AuthController(UserServices userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
        {
            return BadRequest(new LoginResponse { Success = false, ErrorMessage = "Invalid request" });
        }

        // Call the login method
        _userService.DidUserLoginServiceFlutter(loginRequest.Email, loginRequest.Password);

        // Get the user after login
        var user = _userService.GetCurrentUser();

        // Check if login was successful
        if (user == null || !_userService.IsUserLoggedIn)
        {
            return Unauthorized(new LoginResponse { Success = false, ErrorMessage = "Invalid credentials" });
        }

        // Generate JWT token
        var token = GenerateJwtToken(user);

        return Ok(new LoginResponse
        {
            Success = true,
            Token = token,
            UserId = user.UserId,
            UserName = user.UserName
        });
    }

    [HttpGet("user")]
    public IActionResult GetCurrentUser()
    {
        // Get the current user
        var user = _userService.GetCurrentUser();

        // Check if there is a logged-in user
        if (user == null || !_userService.IsUserLoggedIn)
        {
            return Unauthorized();
        }

        return Ok(user);
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        _userService.Logout();
        return Ok(new { Success = true });
    }

    private string GenerateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "YourSecretKeyHere1234567890123456"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId ?? ""),
            new Claim(JwtRegisteredClaimNames.Email, user.UserEmail ?? ""),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"] ?? "YourIssuer",
            audience: _configuration["Jwt:Audience"] ?? "YourAudience",
            claims: claims,
            expires: DateTime.Now.AddHours(3),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}