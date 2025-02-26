using System.Data;
using System;
using Microsoft.AspNetCore.Components;
using OnlineStore.Models;
using System.Linq;

namespace OnlineStore.Data;

public class CartData
{
    public event Action? OnChange;
    public static string cartDataDEtail = string.Empty;
    private List<UserCart> _carts = [
        new(){
            ItemName="Vegetable Peeler",
            ItemCost=130,
            ItemInCart=2
        },
        new(){
            ItemName="Cast Iron Skillet",
            ItemCost=439,
            ItemInCart=1
        },
        new(){
            ItemName="Colander",
            ItemCost=350,
            ItemInCart=1
        },
        new(){
            ItemCost=59,
            ItemInCart=5,
            ItemName="Sponges"
        }
    ];
    private readonly List<Product> BeautyCarts = [];

    public void AddToBeautyCart(Product product)
    {
        BeautyCarts.Add(product);
        NotifyStateChanged();
        Console.WriteLine(@$"{product.ProductName} is added to cart CONFORMED on {DateTime.Now} || product ID: {product.ProductId}");
    }
    public void RemoveFromBeautyCart(Product product)
    {
        BeautyCarts.Remove(product);
        NotifyStateChanged();
        Console.WriteLine(@$"{product.ProductName} is Removed from cart CONFORMED on {DateTime.Now}||product ID: {product.ProductId}");
        cartDataDEtail = $"{product.ProductName} Has Been removed from cart on {DateTime.Now}";
    }

    public IReadOnlyList<Product> GetBeautyCart() => BeautyCarts;
    public IReadOnlyList<UserCart> Carts => _carts;

    private void NotifyStateChanged() => OnChange?.Invoke();
}