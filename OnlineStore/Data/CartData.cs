using System;
using OnlineStore.Components.Pages;
using OnlineStore.Models;

namespace OnlineStore.Data;

public class CartData
{
    public List<UserCart> carts = [
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
}