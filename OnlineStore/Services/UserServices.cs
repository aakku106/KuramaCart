using System;
using OnlineStore.Shared.Models;

namespace OnlineStore.Services;

public class UserServices
{
    private User? _currentUser;

    public bool IsUserLoggedIn { get; private set; } = false;
    public string? UserName { get; private set; }

    public User? GetCurrentUser()
    {
        return _currentUser;
    }

    public void Login(string userName)
    {
        IsUserLoggedIn = true;
        UserName = userName;
    }

    public void DidUserLoginServiceFlutter(string email, string password)
    {
        // Implement actual login logic here
        // For example:
        IsUserLoggedIn = true;
        _currentUser = new User
        {
            UserEmail = email,
            UserPassword = password,
            UserName = "Default User",
            DidUserLogIn = true
        };
    }

    public void Logout()
    {
        IsUserLoggedIn = false;
        UserName = null;
    }
}
