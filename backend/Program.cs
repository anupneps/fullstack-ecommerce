using Api.src.Repositories.ProductRepo;
using backend.src.Db;
using backend.src.DTOs;
using backend.src.Models;
using backend.src.Repositories.AuthenticationRepo;
using backend.src.Repositories.BaseRepo;
using backend.src.Repositories.CategoryRepo;
using backend.src.Repositories.ProductRepo;
using backend.src.Repositories.UserRepo;
using backend.src.Services.AuthenticationService;
using backend.src.Services.BaseService;
using backend.src.Services.CategoryService;
using backend.src.Services.ProductService;
using backend.src.Services.ServiceHash;
using backend.src.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped<IProductRepo, ProductRepo>()
    .AddScoped<IProductService, ProductService>();
builder.Services
    .AddScoped<IUserRepo, UserRepo>()
    .AddScoped<IUserService, UserService>();
builder.Services
    .AddScoped<IAuthenticationRepo, AuthenticationRepo>()
    .AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services
    .AddScoped<ICategoryRepo, CategoryRepo>()
    .AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IServiceHash, ServiceHash>();

/* add configuration for authentication middleware */
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection("AppSettings:Token").Value!
        )),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (dbContext is not null)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
