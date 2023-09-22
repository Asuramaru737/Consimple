using Consimple_Test_Task;
using Consimple_Test_Task.Services;
using Consimple_Test_Task.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProjDbContext>(o =>
    o.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=ShopDB;Trusted_Connection=True;")
);
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IPurchaseService, PurchaseService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
