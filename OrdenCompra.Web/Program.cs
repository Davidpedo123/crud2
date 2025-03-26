using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using crud2.OrdenCompra.Application.Servicios;
using crud2.OrdenCompra.Infrastructure.Data;
using crud2.OrdenCompra.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<OrdenCompraContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de servicios
builder.Services.AddScoped<IServicioOrdenCompra, ServicioOrdenCompra>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();

// Configuración para MVC
builder.Services.AddControllersWithViews(); // <-- Cambia AddControllers() por esto

// Configuración para API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrdenCompra API", Version = "v1" });
});

// CORS (opcional, solo si necesitas consumir desde frontend externo)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrdenCompra API V1");
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // <-- Necesario para MVC (archivos CSS, JS, etc.)

app.UseRouting();

app.UseCors("AllowAll"); // Opcional

app.UseAuthorization();

// Configuración de rutas para MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Configuración adicional para API (si la necesitas)
app.MapControllers();

app.Run();