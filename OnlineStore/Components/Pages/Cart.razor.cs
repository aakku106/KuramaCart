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

    public void RemoveBeautyItemFromCart()
    {
        if (selectedProductInCart != null)
        {
            cartData.RemoveFromBeautyCart(selectedProductInCart);
            selectedProductInCart.HowManyProduct++;
            NumberOfItemInCart--;
            selectedProductInCart = null;
            StateHasChanged();
            return;
        }
    }
    public void RemoveKitchenItemFromCart()
    {
        if (selectedProductInCart != null)
        {
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
        selectedProductInCart = null;
        Data.CartData.cartDataDEtail = string.Empty;
        StateHasChanged();
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