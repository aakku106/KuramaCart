using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using OnlineStore.Client.Services;
using OnlineStore.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Client.Components.Pages
{
    public partial class Kitchen
    {
        private List<Product>? products;
        private Product? selectedProduct;
        private string productDetailsUIMessage = string.Empty;
        private bool isOutOfStock = false;

        [Inject]
        private ProductService ProductService { get; set; } = default!;

        [Inject]
        private CartService CartService { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            products = await ProductService.GetKitchenProductsAsync() ?? new List<Product>();
        }

        private void passToCart(Product product)
        {
            if (product.HowManyProduct > 0)
            {
                selectedProduct = product;
                Console.WriteLine(@$"{selectedProduct.ProductName} passed");
            }
            else
            {
                isOutOfStock = true;
                productDetailsUIMessage = @$"{product?.ProductName} is out of stock, sorry for inConvenance 🥺";
            }
        }

        private async Task AddToCart(Product product)
        {
            await CartService.AddToKitchenCartAsync(product);
            if (selectedProduct != null)
            {
                cartData.AddToKitchenCart(selectedProduct);
                selectedProduct.HowManyProduct--;
                OnlineStore.Components.Pages.Cart.NumberOfItemInCart++;
                Clear();
            }
        }

        private void Clear()
        {
            selectedProduct = null;
            productDetailsUIMessage = string.Empty;
            isOutOfStock = false;
        }

        public void Dispose()
        {
            cartData.OnChange -= StateHasChanged;
        }
    }
}
