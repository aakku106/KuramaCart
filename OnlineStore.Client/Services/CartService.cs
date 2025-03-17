using OnlineStore.Shared.Models;
using System.Net.Http.Json;

namespace OnlineStore.Client.Services;

public class CartService
{
    private readonly HttpClient _httpClient;

    public CartService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Product>> GetCartItemsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Product>>("api/cart") ?? new List<Product>();
    }

    public async Task<bool> AddToCartAsync(Product product)
    {
        var response = await _httpClient.PostAsJsonAsync("api/cart", product);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> RemoveFromCartAsync(int productId)
    {
        var response = await _httpClient.DeleteAsync($"api/cart/{productId}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<Product>?> GetBeautyCartAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Product>>("api/cart/beauty");
    }

    public async Task<List<Product>?> GetKitchenCartAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Product>>("api/cart/kitchen");
    }

    public async Task<bool> AddToBeautyCartAsync(Product product)
    {
        var response = await _httpClient.PostAsJsonAsync("api/cart/beauty", product);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> AddToKitchenCartAsync(Product product)
    {
        var response = await _httpClient.PostAsJsonAsync("api/cart/kitchen", product);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> RemoveFromBeautyCartAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/cart/beauty/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> RemoveFromKitchenCartAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/cart/kitchen/{id}");
        return response.IsSuccessStatusCode;
    }
}