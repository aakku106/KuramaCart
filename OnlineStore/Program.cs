using OnlineStore.Components;
using OnlineStore.Models;
using OnlineStore.Services;
using OnlineStore.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container **before** building the app.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register your services
builder.Services.AddScoped<User, User>();
builder.Services.AddScoped<UserData>();
builder.Services.AddScoped<Product>();
builder.Services.AddScoped<CartData>();
builder.Services.AddScoped<OnlineStore.Data.ProductData.ProductData>();
builder.Services.AddScoped<CartData>();
builder.Services.AddSingleton<UserServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();