using System;
using OnlineStore.Models;

namespace OnlineStore.Components.Pages;

public partial class Cart
{
    private Product? selectedProductInCart;

    private void PassTORemoveFromCart(Product product)
    {
        selectedProductInCart = product;
    }

    public void RemoveFromCart()
    {
        if (selectedProductInCart != null)
        {
            cartData.RemoveFromBeautyCart(selectedProductInCart);
            return;
        }
    }
    protected override void OnInitialized()
    {
        cartData.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        cartData.OnChange -= StateHasChanged;
    }
}