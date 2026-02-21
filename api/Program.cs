using LiberalLibertario.ContactApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Cargar appsettings.Local.json si existe (para desarrollo local con credenciales)
builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);

// Configurar CORS para permitir requests desde tu frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",
                "http://localhost:5174", 
                "https://liberal-libertario.com",
                "https://www.liberal-libertario.com"
            )
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// IMPORTANTE: UseCors debe estar antes de los endpoints
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

// Mapear endpoints
app.MapHealthEndpoints();
app.MapContactEndpoints();

app.Run();
