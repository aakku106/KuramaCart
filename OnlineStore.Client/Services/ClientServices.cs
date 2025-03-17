using Microsoft.Extensions.DependencyInjection;

namespace OnlineStore.Client.Services
{
    public static class ClientServices
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services)
        {
            services.AddScoped<ProductService>();
            services.AddScoped<CartService>();
            services.AddScoped<AuthService>();

            return services;
        }
    }
}