using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data.ProductData;
using OnlineStore.Shared.Models;

namespace OnlineStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductData _productData;

    public ProductsController(ProductData productData)
    {
        _productData = productData;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        // Combine kitchen and beauty products
        var allProducts = _productData.kitchenProducts.Concat(_productData.beautyPublic).ToList();
        return Ok(allProducts);
    }

    [HttpGet("kitchen")]
    public IActionResult GetKitchenProducts()
    {
        return Ok(_productData.kitchenProducts);
    }

    [HttpGet("beauty")]
    public IActionResult GetBeautyProducts()
    {
        return Ok(_productData.beautyPublic); // Changed from beautyProducts to beautyPublic
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _productData.kitchenProducts.FirstOrDefault(p => p.ProductId == id);

        if (product == null)
        {
            product = _productData.beautyPublic.FirstOrDefault(p => p.ProductId == id);
        }

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }
}