// using Internal;
using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using OnlineStore.Data;
using OnlineStore.Models;

namespace OnlineStore.Components.Pages
{
    public partial class Beauty : IDisposable
    {
        private Product? selectedProduct;

        protected override void OnInitialized()
        {
            cartData.OnChange += StateHasChanged;
        }

        private void passToCart(Product product)
        {
            selectedProduct = product;  // Just store the selected product
        }

        private void AddToCart()
        {
            if (selectedProduct != null)
            {
                cartData.AddToBeautyCart(selectedProduct);
                selectedProduct = null;
            }
        }

        public void Dispose()
        {
            cartData.OnChange -= StateHasChanged;
        }
    }
}