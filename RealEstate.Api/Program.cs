using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using RealEstate.Application;
using RealEstate.Infrastructure;
using RealEstate.Infrastructure.Data;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

var config = builder.Configuration;
builder.Services
    .AddInfrastructure(config)
    .AddApplication();

builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddControllers();

// Add a CORS policy for the client
builder.Services.AddCors(
    options => options.AddPolicy(
        "wasm",
        policy => policy.WithOrigins([config["BackendUrl"] ?? "https://localhost:5001",
            config["FrontendUrl"] ?? "https://localhost:5002"])
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()));

// Add services to the container
builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("wasm");

app.UseAuthorization();

app.MapGroup("/account").MapIdentityApi<IdentityUser>();
app.MapControllers();

app.Run();

