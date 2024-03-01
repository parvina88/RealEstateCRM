using Microsoft.AspNetCore.Identity;
using RealEstate.Application;
using RealEstate.Infrastructure;
using RealEstate.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
var config = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services
    .AddInfrastructure(config)
    .AddApplication();

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri(
            builder.Configuration.GetSection("ApiServer")["BaseUri"] ??
                "http://0.0.0.0")
    });

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddBearerToken();

builder.Services.AddAuthorizationBuilder();
    
var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.MapGroup("/identity").MapIdentityApi<IdentityUser>();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
