using System;
using OnlineStore.Models;
using Microsoft.AspNetCore.Components;
using OnlineStore.Client.Services;
using OnlineStore.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Client.Components.Pages
{
    public partial class Cart : IDisposable
    {
        private List<Product> kitchenItems = new();
        private List<Product> beautyItems = new();
        private decimal totalAmount = 0;

        [Inject]
        private CartService CartService { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await LoadCartItems();
        }

        private async Task LoadCartItems()
        {
            kitchenItems = await CartService.GetKitchenCartAsync() ?? new List<Product>();
            beautyItems = await CartService.GetBeautyCartAsync() ?? new List<Product>();

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            totalAmount = 0;

            foreach (var item in kitchenItems)
            {
                totalAmount += item.Price;
            }

            foreach (var item in beautyItems)
            {
                totalAmount += item.Price;
            }
        }

        // Split into two methods to avoid string parameter issues
        private async Task RemoveBeautyItem(Product product)
        {
            await CartService.RemoveFromBeautyCartAsync(product.ProductId);
            await LoadCartItems();
        }

        private async Task RemoveKitchenItem(Product product)
        {
            await CartService.RemoveFromKitchenCartAsync(product.ProductId);
            await LoadCartItems();
        }

        private void GoToCheckout()
        {
            NavigationManager.NavigateTo("/checkout");
        }

        public void Dispose()
        {
            // Cleanup code if needed
        }
    }
}