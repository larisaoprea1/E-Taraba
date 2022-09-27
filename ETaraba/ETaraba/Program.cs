using ETaraba.Domain.Models;
using ETaraba.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ETaraba.Infrastructure.Repositories;
using ETaraba.Application.IRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Db Context
builder.Services.AddDbContext<ETarabaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ETarabaContext") ?? throw new InvalidOperationException("Connection string 'ETarabaContext' not found.")));

builder.Services
    .AddIdentity<User, UserRole>()
    .AddEntityFrameworkStores<ETarabaContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<User, UserRole, ETarabaContext, Guid>>()
    .AddRoleStore<RoleStore<UserRole, ETarabaContext, Guid>>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderProductRepository, OrderProductRepository>();
builder.Services.AddScoped<IBasketProductRepository, BasketProductRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
