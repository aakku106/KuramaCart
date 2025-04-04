using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using OnlineStore.Data;
using OnlineStore.Models;
namespace OnlineStore.Components.Pages;

public partial class Kitchen
{
    private Product? selectedProduct;
    private string productDetailsUIMessage = string.Empty;
    private bool isOutOfStock = false;

    protected override void OnInitialized()
    {
        cartData.OnChange += StateHasChanged;
    }

    private void passToCart(Product product)
    {
        if (authService.IsUserLoggedIn)
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
    }

    private void AddToCart()
    {
        if (selectedProduct != null && authService.IsUserLoggedIn)
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
