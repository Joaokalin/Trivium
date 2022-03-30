using Microsoft.EntityFrameworkCore;
using TriviumApi.Infra;
using TriviumApi.Models.Contracts;
using TriviumApi.Models.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddTransient<ICustomerService, CustomerService>();
services.AddTransient<IProductService, ProductService>();
services.AddTransient<IPurchaseService, PurchaseService>();

services.AddDbContext<ApiDbContext>(options => options.UseNpgsql( builder.Configuration["Database:ConnectionStringPgsql"], pgsql =>
{
    pgsql.EnableRetryOnFailure();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
