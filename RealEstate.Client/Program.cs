using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RealEstate.Client;
using RealEstate.Client.Authentication;
using RealEstate.Client.Services.Auth;
using RealEstate.Client.Services.Building;
using RealEstate.Client.Services.HttpClients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddHttpClient("RealEstate.Api", client =>
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => 
sp.GetRequiredService<IHttpClientFactory>().CreateClient("RealEstate.Api"));

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpClient();
builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
