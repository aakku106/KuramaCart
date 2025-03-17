using OnlineStore.Shared.Models;
using System.Net.Http.Json;

namespace OnlineStore.Client.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Product>?> GetBeautyProductsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Product>>("api/products/beauty");
    }

    public async Task<List<Product>?> GetKitchenProductsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Product>>("api/products/kitchen");
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
    }
}