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
    private static readonly List<Product> KitchenCarts = [];
    private static readonly List<Product> BeautyCarts = [];

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
    public void AddToKitchenCart(Product product)
    {
        KitchenCarts.Add(product);
        NotifyStateChanged();
        Console.WriteLine(@$"{product.ProductName} is added to cart CONFORMED on {DateTime.Now} || product ID: {product.ProductId}");
    }
    public void RemoveFromKitchenCart(Product product)
    {
        KitchenCarts.Remove(product);
        NotifyStateChanged();
        Console.WriteLine(@$"{product.ProductName} is Removed from cart CONFORMED on {DateTime.Now}||product ID: {product.ProductId}");
        cartDataDEtail = $"{product.ProductName} Has Been removed from cart on {DateTime.Now}";
    }

    public IReadOnlyList<Product> GetBeautyCart() => BeautyCarts;
    public IReadOnlyList<Product> GetKitchenCart() => KitchenCarts;
    private void NotifyStateChanged() => OnChange?.Invoke();
}
