using PManage.Infrastructure.Repositories;
using PManage.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using PManage.Application.Services;
using PManage.Infrastructure.Data;
using PManage.Domain.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register IProductService and its implementation ProductService
builder.Services.AddScoped<IProductService, ProductService>();

// Register IProductRepository and its implementation ProductRepository
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Register the ApplicationDbContext with PostgreSQL (Npgsql)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the Swagger/OpenAPI documentation generator
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Product API",
        Version = "v1",
        Description = "API para gerenciamento de produtos. Permite operações como criar, listar, atualizar e deletar produtos.",
        Contact = new OpenApiContact
        {
            Name = "Danilo O. Pinheiro",
            Email = "contato@dopme.io",
            Url = new Uri("https://www.linkedin.com/in/daniloopinheiro/")
        }
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

app.UseAuthorization();

app.MapControllers();

app.Run();
