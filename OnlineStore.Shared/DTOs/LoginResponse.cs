namespace OnlineStore.Shared.DTOs;

public class LoginResponse
{
    public string? Token { get; set; }
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}