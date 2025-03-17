using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data;
using OnlineStore.Shared.Models;
using System.Linq;
using System.Collections.Generic;

namespace OnlineStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly CartData _cartData;

    public CartController(CartData cartData)
    {
        _cartData = cartData;
    }

    // Get all cart items
    [HttpGet]
    public IActionResult GetCartItems()
    {
        var beautyCart = _cartData.GetBeautyCart() ?? new List<Product>();
        var kitchenCart = _cartData.GetKitchenCart() ?? new List<Product>();
        var allItems = beautyCart.Concat(kitchenCart).ToList();
        return Ok(allItems);
    }

    // Beauty cart endpoints
    [HttpGet("beauty")]
    public IActionResult GetBeautyCart()
    {
        var items = _cartData.GetBeautyCart() ?? new List<Product>();
        return Ok(items);
    }

    [HttpPost("beauty")]
    public IActionResult AddToBeautyCart([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest();
        }

        _cartData.AddToBeautyCart(product);
        return Ok(true);
    }

    [HttpDelete("beauty/{id}")]
    public IActionResult RemoveFromBeautyCart(int id)
    {
        var items = _cartData.GetBeautyCart();
        var product = items.FirstOrDefault(p => p.ProductId == id);

        if (product == null)
        {
            return NotFound();
        }

        _cartData.RemoveFromBeautyCart(product);
        return Ok(true);
    }

    // Kitchen cart endpoints
    [HttpGet("kitchen")]
    public IActionResult GetKitchenCart()
    {
        var items = _cartData.GetKitchenCart() ?? new List<Product>();
        return Ok(items);
    }

    [HttpPost("kitchen")]
    public IActionResult AddToKitchenCart([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest();
        }

        _cartData.AddToKitchenCart(product);
        return Ok(true);
    }

    [HttpDelete("kitchen/{id}")]
    public IActionResult RemoveFromKitchenCart(int id)
    {
        var items = _cartData.GetKitchenCart();
        var product = items.FirstOrDefault(p => p.ProductId == id);

        if (product == null)
        {
            return NotFound();
        }

        _cartData.RemoveFromKitchenCart(product);
        return Ok(true);
    }
}