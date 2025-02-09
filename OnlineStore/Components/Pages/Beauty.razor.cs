using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using OnlineStore.Data;
using OnlineStore.Models;

namespace OnlineStore.Components.Pages
{
    public partial class Beauty
    {
        private OnlineStore.Models.Product? selectedProduct;

        protected override void OnInitialized()
        {
            cartData.OnChange += StateHasChanged;
        }

        private void passToCart(Models.Product product)
        {
            selectedProduct = product;
        }

        private void AddToCart()
        {
            if (selectedProduct != null)
            {
                cartData.AddToBeautyCart(selectedProduct);

                selectedProduct = null;
            }
        }
    }
}