namespace LiberalLibertario.ContactApi.Endpoints;

public static class HealthEndpoint
{
    public static void MapHealthEndpoints(this WebApplication app)
    {
        app.MapGet("/api/health", () => Results.Ok(new { status = "healthy", timestamp = DateTime.UtcNow }))
            .WithName("HealthCheck");
    }
}