using System;

namespace OnlineStore.Services;

public class UserServices
{

    public bool IsUserLoggedIn { get; private set; } = false;
    public string? UserName { get; private set; }

    public void Login(string userName)
    {
        IsUserLoggedIn = true;
        UserName = userName;
    }

    public void Logout()
    {
        IsUserLoggedIn = false;
        UserName = null;
    }

}
