using Application.Interfaces;
using Application.UseCases;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; // Add this using directive
using Swashbuckle.AspNetCore.SwaggerGen; // Add this using directive

var builder = WebApplication.CreateBuilder(args);

// Add connection to database 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.EnableRetryOnFailure()
    ));

//Swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // This will now resolve

// Register repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

// Register Generate JWT Token Service
builder.Services.AddScoped<IJWTService, JwtService>();
builder.Services.AddControllers();

// Register Use Case
builder.Services.AddScoped<RegisterTenantUseCase>();
builder.Services.AddScoped<RegisterUserUseCase>();
builder.Services.AddScoped<LoginUserUseCase>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
