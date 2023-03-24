using Api.src.Repositories.ProductRepo;
using backend.src.Authorization;
using backend.src.Db;
using backend.src.Helpers;
using backend.src.Repositories.AuthenticationRepo;
using backend.src.Repositories.CategoryRepo;
using backend.src.Repositories.ProductRepo;
using backend.src.Repositories.UserRepo;
using backend.src.Services.AuthenticationService;
using backend.src.Services.CategoryService;
using backend.src.Services.ProductService;
using backend.src.Services.ServiceHash;
using backend.src.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
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

builder.Services
    .AddDbContext<AppDbContext>()
    .AddAutoMapper(typeof(Program).Assembly)
    .AddSingleton(AutoMappingConfig.RegisterMapping());

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition(
            "oauth2",
            new OpenApiSecurityScheme
            {
                Description = "Bearer token authentication",
                Name = "Authorization",
                In = ParameterLocation.Header,
            }
        );
        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });

builder.Services
    .AddScoped<IProductRepo, ProductRepo>()
    .AddScoped<IProductService, ProductService>()
    .AddScoped<IUserRepo, UserRepo>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IAuthenticationRepo, AuthenticationRepo>()
    .AddScoped<IAuthenticationService, AuthenticationService>()
    .AddScoped<ICategoryRepo, CategoryRepo>()
    .AddScoped<ICategoryService, CategoryService>()
    .AddScoped<IServiceHash, ServiceHash>()
    .AddScoped<IAuthorizationRequirement, UpdateUserRequirement>();

/* add configuration for authentication middleware */

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                builder.Configuration.GetValue<string>("Jwt:Token")!
            )),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Mypolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                "https://hilarious-pasca-58c602.netlify.app/")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});


builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
        options.AddPolicy("AdminOrValidUser", policy => policy.AddRequirements(new UpdateUserRequirement()));
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("Mypolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
