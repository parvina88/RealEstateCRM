using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using RealEstate.Application;
using RealEstate.Infrastructure;
using RealEstate.Infrastructure.Data;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
builder.Services
    .AddInfrastructure(config)
    .AddApplication();

//builder.Services.AddIdentityCore<IdentityUser>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddApiEndpoints();

//builder.Services.AddIdentityApiEndpoints<IdentityUser>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("api", p =>
    {
        p.RequireAuthenticatedUser();
        p.AddAuthenticationSchemes(IdentityConstants.BearerScheme);
    });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();

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

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp", builder =>
    {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});

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
app.UseCors("corsapp");

app.UseAuthorization();

app.MapGroup("/account").MapIdentityApi<IdentityUser>();
app.MapControllers();

app.Run();

