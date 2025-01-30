using OnlineStore.Components;
using OnlineStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container **before** building the app.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register your services
builder.Services.AddScoped<User, User>();
builder.Services.AddSingleton<OnlineStore.Data.UserData>();


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