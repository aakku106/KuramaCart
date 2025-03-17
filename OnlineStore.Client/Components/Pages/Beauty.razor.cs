using Microsoft.AspNetCore.Components;
using OnlineStore.Client.Services;
using OnlineStore.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Client.Components.Pages
{
    public partial class Beauty
    {
        private List<Product>? products;

        [Inject]
        private ProductService ProductService { get; set; } = default!;

        [Inject]
        private CartService CartService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            products = await ProductService.GetBeautyProductsAsync();
        }

        private async Task AddToCart(Product product)
        {
            await CartService.AddToBeautyCartAsync(product);
        }
    }
}