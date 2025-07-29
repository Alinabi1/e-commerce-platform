using Microsoft.EntityFrameworkCore;
using user_service.Data;


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

// Swagger (om du vill ha det)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware
// app.UseHttpsRedirection();  // valfritt
app.UseAuthorization();

// Lägg till detta för att mappa dina controllers (t.ex. TasksController):
app.MapControllers();

app.MapHealthChecks("/health");

app.Run();