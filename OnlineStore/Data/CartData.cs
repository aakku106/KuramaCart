using System;
using Microsoft.AspNetCore.Components;
using OnlineStore.Models;
using System.Linq;

namespace OnlineStore.Data;

public class CartData
{
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

    public IReadOnlyList<UserCart> Carts => _carts;
}