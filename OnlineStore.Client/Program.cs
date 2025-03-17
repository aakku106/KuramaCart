using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OnlineStore.Client;
using OnlineStore.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HttpClient to point to your server
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5142") });

// Register client-side services
builder.Services.AddClientServices();

await builder.Build().RunAsync();
