using System;
using OnlineStore.Models;

namespace OnlineStore.Components.Pages;

public partial class LoginPage
{
    private string conformPassword = string.Empty;
    private string? loginMessage;
    private int ID = 0;

    private User userLogin { get; set; } = new()
    {
        UserName = string.Empty,
        UserEmail = string.Empty,
        UserId = string.Empty,
        UserPassword = string.Empty,
        DateTime = DateTime.UtcNow,
        DidUserLogIn = false,
    };

    private void Login()
    {
        var user = userData.AuthenticateUser(userLogin.UserName, userLogin.UserEmail, userLogin.UserPassword);

        if (user != null)
        {
            loginMessage = $"🎉 Login successful! Welcome, {user.UserName}";
            user.DidUserLogIn = true;
            userDetails.DidUserLogIn = true;
            Navigation.NavigateTo("/Home");
        }
        else
        {
            loginMessage = "❌ Invalid username or password. Please try again.";
            ClearInputs();
        }
    }
    private void SignUp()
    {
        if (userLogin.UserPassword != conformPassword)
        {
            loginMessage = $" {userLogin.UserPassword} ≠{conformPassword} please try again 👀";
        }
        else
        {
            userData.AddUser(ID.ToString(), userLogin.UserName, userLogin.UserEmail, conformPassword);
            ID += 106;
            loginMessage = $"User {userLogin.UserName} is created on {DateTime.Now} with id \t{ID + "A76Z"} ";
            ClearInputs();
            return;
        }
    }
    private void ClearInputs()
    {
        userLogin.UserName = userLogin.UserEmail = userLogin.UserPassword = conformPassword = string.Empty;
    }
    private void ClearInputsOnChange()
    {
        userLogin.UserName = userLogin.UserEmail = userLogin.UserPassword = conformPassword = loginMessage = string.Empty;
    }
}
