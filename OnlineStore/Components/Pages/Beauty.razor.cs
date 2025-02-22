// using Internal;
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
            Console.WriteLine(@$"selected {selectedProduct.ProductName}");

            selectedProduct = product;
        }

        private void AddToCart()
        {
            Console.WriteLine(@$"{selectedProduct.ProductName} added in cart");
            if (selectedProduct != null)
            {
                cartData.AddToBeautyCart(selectedProduct);
                Console.WriteLine(@$"{selectedProduct.ProductName} added in cart for sure 🐶");


                selectedProduct = null;
            }
        }
    }
}