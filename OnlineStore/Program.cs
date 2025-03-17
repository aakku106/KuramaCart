using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Shared.Models;
using OnlineStore.Services;
using OnlineStore.Data;
using OnlineStore.Data.ProductData;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); // Add this instead of Razor Components
builder.Services.AddEndpointsApiExplorer(); // Add for API documentation
builder.Services.AddSwaggerGen(); // Optional: Add Swagger for API testing

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClientPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7179", "http://localhost:5237")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? "OnlineStore",
            ValidAudience = builder.Configuration["Jwt:Audience"] ?? "OnlineStoreClient",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration["Jwt:Key"] ?? "YourSecretKeyHere1234567890123456"))
        };
    });

// Register your services
builder.Services.AddScoped<User>();
builder.Services.AddScoped<UserData>();
builder.Services.AddScoped<Product>();
builder.Services.AddScoped<CartData>();
builder.Services.AddScoped<ProductData>();
builder.Services.AddSingleton<UserServices>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5142") });

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Optional: Use Swagger in development
    app.UseSwaggerUI(); // Optional: Use Swagger UI in development
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Use CORS before Auth
app.UseCors("BlazorClientPolicy");

// Use Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

// Map API controllers
app.MapControllers();

// REMOVE the MapRazorComponents and MapFallbackToPage calls
// Instead, add a simple fallback for API
app.MapFallback(context =>
{
    context.Response.StatusCode = 404;
    return Task.CompletedTask;
});

app.Run();