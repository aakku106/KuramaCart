using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Shared.Models;

public class User
{
    public string? UserId { get; set; }
    
    [Required(ErrorMessage = "User Name is required")]
    public string? UserName { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? UserEmail { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
    public string? UserPassword { get; set; }
    
    public bool DidUserLogIn { get; set; } = false;
    
    public string? ProfilePicture { get; set; } = "/images/default-profile.png";
}