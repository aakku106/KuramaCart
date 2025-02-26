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

    public async Task RemoveFromCart()
    {
        if (selectedProductInCart != null)
        {
            await Task.Delay(300);

            cartData.RemoveFromBeautyCart(selectedProductInCart);
            selectedProductInCart = null;
            StateHasChanged();
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