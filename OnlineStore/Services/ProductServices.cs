using System;
using OnlineStore.Models;

namespace OnlineStore.Services;

public class ProductServices
{
    private List<Product> products = [
    new(){
ProductId=123,
ProductName="kuramaPack",
Price=106,
Date= new DateOnly(2025,01,26)
},
new(){
    ProductId=321,
    ProductName="SonGoku",
    Price=1314
}
    ];

    public Product[] GetProduct() => [.. products];

}
