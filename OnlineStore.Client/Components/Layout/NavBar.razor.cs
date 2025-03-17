using Microsoft.AspNetCore.Components;
using OnlineStore.Client.Services;
using OnlineStore.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Client.Components.Layout
{
    public partial class NavBar : IDisposable
    {
        private bool isLoggedIn = false;
        private string? userName;
        private List<Product> searchResults = new();
        private string searchQuery = "";
        private bool showResults = false;
        private string UserProfilePic = "/images/default-profile.png"; // Default profile pic

        [Inject]
        private AuthService AuthService { get; set; } = default!;

        [Inject]
        private ProductService ProductService { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await CheckLoginState();
        }

        private async Task CheckLoginState()
        {
            var user = await AuthService.GetCurrentUserAsync();
            isLoggedIn = user != null;
            userName = user?.UserName;

            // If user profile picture exists, use it
            if (user != null && !string.IsNullOrEmpty(user.ProfilePicture))
            {
                UserProfilePic = user.ProfilePicture;
            }
        }

        private async Task LogoutAsync()
        {
            await AuthService.LogoutAsync();
            await CheckLoginState();
            NavigationManager.NavigateTo("/");
        }

        private async Task HandleSearch(ChangeEventArgs e)
        {
            searchQuery = e.Value?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                searchResults.Clear();
                showResults = false;
                return;
            }

            // In real implementation, call API to search products
            var kitchenProducts = await ProductService.GetKitchenProductsAsync() ?? new List<Product>();
            var beautyProducts = await ProductService.GetBeautyProductsAsync() ?? new List<Product>();

            searchResults = kitchenProducts.Concat(beautyProducts)
                .Where(p => p.ProductName != null &&
                       p.ProductName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                .ToList();

            showResults = searchResults.Any();
        }

        private void NavigateToProduct(Product product)
        {
            showResults = false;
            NavigationManager.NavigateTo($"/product/{product.ProductId}");
        }

        private void HideResults()
        {
            // Short delay to allow click handling before hiding results
            Task.Delay(200).ContinueWith(_ =>
            {
                showResults = false;
                StateHasChanged();
            });
        }

        public void Dispose()
        {
            // Add any cleanup code here
        }
    }
}