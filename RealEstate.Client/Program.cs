using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RealEstate.Client;
using RealEstate.Client.Services.Building;
using RealEstate.Client.Services.HttpClients;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddScoped<IBuildingService, BuildingService>();

//In order to authenticate to IS4:
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpClient();
builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
