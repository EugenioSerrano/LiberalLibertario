using MailKit.Net.Smtp;
using MimeKit;

namespace LiberalLibertario.ContactApi.Endpoints;

public static class ContactEndpoint
{
    public static void MapContactEndpoints(this WebApplication app)
    {
        app.MapPost("/api/contact", SendContactAsync)
            .WithName("SendContact");
    }

    private static async Task<IResult> SendContactAsync(
        ContactRequest request,
        IConfiguration configuration,
        ILogger<Program> logger,
        HttpContext httpContext)
    {
        try
        {
            // Validar API Key
            var apiKey = configuration["ApiKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                logger.LogError("API Key not configured in appsettings");
                return Results.Problem("Error de configuración del servidor");
            }

            // Obtener API Key del header
            if (!httpContext.Request.Headers.TryGetValue("X-API-Key", out var providedApiKey))
            {
                logger.LogWarning("Missing X-API-Key header");
                return Results.Unauthorized();
            }

            // Comparar API Keys
            if (providedApiKey != apiKey)
            {
                logger.LogWarning("Invalid API Key provided");
                return Results.Unauthorized();
            }

            // Validar request
            if (string.IsNullOrWhiteSpace(request.Name) ||
                string.IsNullOrWhiteSpace(request.Contact) ||
                string.IsNullOrWhiteSpace(request.Localidad) ||
                string.IsNullOrWhiteSpace(request.Message))
            {
                return Results.BadRequest(new { error = "Todos los campos son requeridos" });
            }

            // Obtener configuración de email desde appsettings o variables de entorno
            var smtpHost = configuration["Email:SmtpHost"];
            var smtpPort = int.Parse(configuration["Email:SmtpPort"] ?? "587");
            var smtpUser = configuration["Email:SmtpUser"];
            var smtpPass = configuration["Email:SmtpPassword"];
            var toEmails = configuration["Email:ToEmail"];

            if (string.IsNullOrEmpty(smtpHost) || string.IsNullOrEmpty(smtpUser) ||
                string.IsNullOrEmpty(smtpPass) || string.IsNullOrEmpty(toEmails))
            {
                logger.LogError("Email configuration is missing");
                return Results.Problem("Error de configuración del servidor");
            }

            // Crear el mensaje
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sitio Web Liberal Libertario", smtpUser));
            
            // Agregar múltiples destinatarios (separados por coma)
            var emailAddresses = toEmails.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var email in emailAddresses)
            {
                message.To.Add(MailboxAddress.Parse(email.Trim()));
            }
            message.Subject = $"Contacto desde el sitio web: {request.Name}";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif;'>
                        <h2>Nuevo mensaje de contacto</h2>
                        <p><strong>Nombre:</strong> {request.Name}</p>
                        <p><strong>Contacto:</strong> {request.Contact}</p>
                        <p><strong>Localidad:</strong> {request.Localidad}</p>
                        <p><strong>Mensaje:</strong></p>
                        <div style='padding: 15px; background-color: #f5f5f5; border-left: 3px solid #F2B400;'>
                            {request.Message.Replace("\n", "<br>")}
                        </div>
                        <hr>
                        <p style='color: #666; font-size: 12px;'>
                            Enviado desde: liberal-libertario.com<br>
                            Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}
                        </p>
                    </body>
                    </html>
                "
            };

            message.Body = bodyBuilder.ToMessageBody();

            // Enviar el email
            using var client = new SmtpClient();
            await client.ConnectAsync(smtpHost, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(smtpUser, smtpPass);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);

            logger.LogInformation("Email sent successfully from {Name} ({Contact})", request.Name, request.Contact);

            return Results.Ok(new { success = true, message = "Mensaje enviado correctamente" });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error sending email");
            return Results.Problem("Error al enviar el mensaje. Por favor, intentá nuevamente.");
        }
    }
}

// Modelo para el request de contacto
public record ContactRequest(string Name, string Contact, string Localidad, string Message);