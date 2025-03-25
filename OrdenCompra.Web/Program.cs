using Microsoft.EntityFrameworkCore;

using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;

using crud2.OrdenCompra.Infraestructure;       // Si OrdenCompraContext está en este namespace
using crud2.OrdenCompra.Application.Interfaces;   // Para IOrdenCompraService, IProveedorService
       // Para OrdenCompraService, ProveedorService (si es que están allí)


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IServicioOrdenCompra, IServicioOrdenCompra>();
builder.Services.AddScoped<IProveedorService, IProveedorService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
