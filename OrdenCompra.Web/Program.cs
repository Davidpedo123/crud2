using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using crud2.OrdenCompra.Application.Servicios;
using crud2.OrdenCompra.Infrastructure.Data;
using crud2.OrdenCompra.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<OrdenCompraContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IServicioOrdenCompra, ServicioOrdenCompra>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();



builder.Services.AddControllersWithViews(); 


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddControllers()
    .AddApplicationPart(typeof(crud2.OrdenCompra.Api.Controllers.OrdenCompraControllerAPI).Assembly);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrdenCompra API V1");
        c.RoutePrefix = "swagger"; 
    });
}


app.UseExceptionHandler("/Home/Error");
app.UseHsts();
app.UseHttpsRedirection();

app.UseStaticFiles(); 
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();


app.MapControllers(); 


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();