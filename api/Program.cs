using LiberalLibertario.ContactApi.Endpoints;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

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

// Configurar archivos estáticos desde la carpeta assets
var assetsPath = Path.Combine(app.Environment.ContentRootPath, "assets");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(assetsPath),
    RequestPath = "/assets",
    OnPrepareResponse = ctx =>
    {
        // Agregar headers CORS manualmente para archivos estáticos
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
        // Cache por 1 año para archivos estáticos
        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=31536000");
    }
});

app.UseHttpsRedirection();

// Mapear endpoints
app.MapHealthEndpoints();
app.MapContactEndpoints();

app.Run();
