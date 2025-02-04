using System;
using OnlineStore.Models;

namespace OnlineStore.Data;

public class ProductData
{

    private readonly List<Product> products =
    [
    new(){
ProductId=123,
ProductName="kuramaPack",
Price=106,
Date= new DateOnly(2025,01,26)
},
new(){
    ProductId=321,
    ProductName="SonGoku",
    Price=1314,
    Date=null
},
new(){
    ProductId=321,
    ProductName="SonGoku",
    Price=1314,
    Date=null
},
new(){
    ProductId=112,
    ProductName="Vegetable Peeler",
    Price=130,
    Date=null,
    HowManyProduct=5
},
new(){
    ProductId=3221,
    ProductName="Food Storage Containers (Premium)",
    Price=500,
    Date=null,
    HowManyProduct=3
},
new(){
    ProductId=11111,
    ProductName="Sponges",
    Price=59,
    Date=null,
    HowManyProduct=157
},
new(){
    ProductId=121212,
    ProductName="Large Trash Bin",
    Price=549,
    Date=null,
    HowManyProduct=7
},
new(){
    ProductId=989252,
    ProductName="Whisk",
    Price=120,
    Date=null,
    HowManyProduct=13
},
new(){
    ProductId=341434,
    ProductName="Shears",
    Price=50,
    Date=null,
    HowManyProduct=2
},
new(){
    ProductId=765875423,
    ProductName="Colander",
    Price=350,
    Date=null,
    HowManyProduct=9
}












    ];

    public Product[] GetProduct() => [.. products];
}
