using System;
using Microsoft.AspNetCore.Components;
using OnlineStore.Models;
using System.Linq;

namespace OnlineStore.Data;

public class CartData
{
    public event Action? OnChange;
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
    // private readonly List<Product> BeautyCarts = [];
    public List<Product> BeautyCarts = [];// this is temp public list just used to showcase example, use upper private for more secure use

    public void AddToBeautyCart(Product product)
    {
        BeautyCarts.Add(product);
        NotifyStateChanged();
    }

    // public IReadOnlyList<Product> GetBeautyCart() => BeautyCarts;

    public IReadOnlyList<UserCart> Carts => _carts;

    private void NotifyStateChanged() => OnChange?.Invoke();
}