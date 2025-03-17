using System;
using Microsoft.AspNetCore.Components;
using OnlineStore.Client.Services;
using OnlineStore.Shared.Models;
using System.Threading.Tasks;

namespace OnlineStore.Client.Components.Pages
{
    public partial class LoginPage
    {
        private string email = "";
        private string password = "";
        private string errorMessage = "";
        private bool loading = false;

        [Inject]
        private AuthService AuthService { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        private async Task HandleLogin()
        {
            loading = true;
            errorMessage = "";

            try
            {
                var success = await AuthService.LoginAsync(email, password);

                if (success)
                {
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    errorMessage = "Invalid email or password";
                }
            }
            catch
            {
                errorMessage = "An error occurred during login";
            }
            finally
            {
                loading = false;
            }
        }
    }
}
