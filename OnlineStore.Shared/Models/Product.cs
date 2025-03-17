using System;

namespace OnlineStore.Shared.Models;

public class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public DateTime? Date { get; set; }
    public int HowManyProduct { get; set; }
    public string? ProductType { get; set; }
    public string? ImagePath { get; set; }
}
