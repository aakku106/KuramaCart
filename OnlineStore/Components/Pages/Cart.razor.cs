using System;
using OnlineStore.Models;

namespace OnlineStore.Components.Pages;
public partial class Cart
{
    private Product? selectedProductInCart;
    public static int NumberOfItemInCart = 0;

    private void PassTORemoveFromCart(Product product)
    {
        selectedProductInCart = product;
    }

    public async Task RemoveBeautyItemFromCart()
    {
        if (selectedProductInCart != null)
        {
            await Task.Delay(300);
            cartData.RemoveFromBeautyCart(selectedProductInCart);
            selectedProductInCart.HowManyProduct++;
            NumberOfItemInCart--;
            selectedProductInCart = null;
            StateHasChanged();
            return;
        }
    }
    public async Task RemoveKitchenItemFromCart()
    {
        if (selectedProductInCart != null)
        {
            await Task.Delay(300);
            cartData.RemoveFromKitchenCart(selectedProductInCart);
            selectedProductInCart.HowManyProduct++;
            NumberOfItemInCart--;
            selectedProductInCart = null;
            StateHasChanged();
            return;
        }
    }

    private void Clear()
    {
        StateHasChanged();
        selectedProductInCart = null;
        Data.CartData.cartDataDEtail = string.Empty;
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