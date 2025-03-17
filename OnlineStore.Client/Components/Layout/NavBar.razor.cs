using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Components;
using OnlineStore.Models;
using OnlineStore.Data;

namespace OnlineStore.Components.Layout
{
    public partial class NavBar
    {
        [Inject]
        private OnlineStore.Data.ProductData.ProductData? ProductData { get; set; }

        private string searchQuery = "";
        private List<Product> searchResults = new();
        private bool showResults = false;
        private Timer? searchDebounceTimer;
        private const int DEBOUNCE_DELAY = 300;

        private void HandleSearch(ChangeEventArgs e)
        {
            searchQuery = e.Value?.ToString() ?? "";

            searchDebounceTimer?.Dispose();

            searchDebounceTimer = new Timer(_ =>
            {
                if (string.IsNullOrWhiteSpace(searchQuery))
                {
                    searchResults.Clear();
                    showResults = false;
                }
                else
                {
                    var allProducts = new List<Product>();
                    allProducts?.AddRange(ProductData.beautyPublic);

                    searchResults = allProducts
                        .Where(p => p.ProductName.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    showResults = searchResults.Any();
                }

                InvokeAsync(StateHasChanged);
            }, null, DEBOUNCE_DELAY, Timeout.Infinite);
        }

        private void HideResults()
        {
            showResults = false;
        }

        private void NavigateToProduct(Product product)
        {
            showResults = false;
        }
        private string UserProfilePic { get; set; } = "/images/naruto-kurama-bg.png";
        
        private void Logout()
        {
            Console.WriteLine("User logged out!");
            authService.Logout();
        }


        public void Dispose()
        {
            searchDebounceTimer?.Dispose();
        }
    }
}
