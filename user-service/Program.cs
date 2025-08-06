using Microsoft.EntityFrameworkCore;
using User_service.Data;


var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:8080");

// Lägg till detta för att aktivera MVC controllers:
builder.Services.AddControllers();

builder.Services.AddHealthChecks();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));


var app = builder.Build();


// Middleware
// app.UseHttpsRedirection();  // valfritt
app.UseAuthorization();

// Lägg till detta för att mappa dina controllers (t.ex. TasksController):
app.MapControllers();

app.MapHealthChecks("/health");

app.Run();