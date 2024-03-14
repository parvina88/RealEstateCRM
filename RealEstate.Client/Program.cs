using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RealEstate.Client;
using RealEstate.Client.Authentication;
using RealEstate.Client.Services.Auth;
using RealEstate.Client.Services.Building;
using RealEstate.Client.Services.HttpClients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IAuthService, AuthService>();   
builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddScoped<IBuildingService, BuildingService>();

builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
// register the account management interface
builder.Services.AddScoped(
    sp => (IHttpClientFactory)sp.GetRequiredService<AuthenticationStateProvider>());

// configure client for auth interactions
//builder.Services.AddHttpClient(
//    "Auth",
//    opt => opt.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:5001"))
//    .AddHttpMessageHandler<IHttpClientService>();


builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpClient();
builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
