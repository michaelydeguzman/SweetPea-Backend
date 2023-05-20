using DataAccess;
using DataAccess.Interfaces;
using MenuService.Data.Repository;
using MenuService.Data.Repository.Interfaces;
using MenuService.Repositories.Persistence;
using MenuService.Services;
using MenuService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Enable CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// DbContext
var connectionString = builder.Configuration.GetConnectionString("MenuServiceDb");

builder.Services.AddDbContext<MenuServiceDbContext>(options =>
    options.UseSqlServer(connectionString,
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    }));

// Repositories
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IMenuGroupRepository, MenuGroupRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddTransient<IProductService, ProductService>();

//services.AddTransient<IServiceWrapper, ServiceWrapper>();
//services.AddTransient<IAuthManager, AuthManager>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
