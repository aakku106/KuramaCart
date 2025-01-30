using System;

namespace OnlineStore.Models;

public class Product
{
    public required int ProductId { get; set; }
    public required string ProductName { get; set; }
    public required decimal Price { get; set; }
    public DateOnly? Date { get; set; }

}
