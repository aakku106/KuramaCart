using System;

namespace OnlineStore.Models;

public class UserCart
{
    public int ItemInCart { get; set; } = 0;
    public string ItemName { get; set; } = string.Empty;
    public decimal ItemCost{get;set;}

}
