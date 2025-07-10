var builder = WebApplication.CreateBuilder(args);

// Lägg till detta för att aktivera MVC controllers:
builder.Services.AddControllers();

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

app.Run();