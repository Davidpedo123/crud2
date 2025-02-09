using Microsoft.EntityFrameworkCore;
using crud2.Data; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<InstitucionesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


app.UseStaticFiles();

app.UseAuthorization();


app.MapControllers();

app.Run();
