# Contact API - Liberal Libertario

API minimalista en .NET 10 para manejar el formulario de contacto del sitio web.

## Configuración

### 1. Desarrollo Local

Creá el archivo `appsettings.Local.json` con tus credenciales reales:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "Email": {
    "SmtpHost": "smtp.gmail.com",
    "SmtpPort": "587",
    "SmtpUser": "tu-email@gmail.com",
    "SmtpPassword": "tu-password-de-aplicacion",
    "ToEmail": "destinatario@ejemplo.com"
  }
}
```

**⚠️ IMPORTANTE:** Este archivo NO se sube a git (está en `.gitignore`)

**Para Gmail:**
1. Activá la verificación en dos pasos
2. Generá una "Contraseña de aplicación" en https://myaccount.google.com/apppasswords
3. Usá esa contraseña en `SmtpPassword`

### 2. Producción (servidor)

Copiá el archivo `appsettings.Local.json` manualmente a la carpeta de publicación en tu servidor.

## Ejecutar localmente

``bash
dotnet run
``

La API correr� en `https://localhost:5001` (HTTPS) y `http://localhost:5000` (HTTP)

## Endpoints

### POST /api/contact
Env�a un email de contacto.

**Request:**
``json
{
  \"name\": \"Juan P�rez\",
  \"contact\": \"juan@ejemplo.com\",
  \"message\": \"Mensaje de prueba\"
}
``

**Response (200):**
``json
{
  \"success\": true,
  \"message\": \"Mensaje enviado correctamente\"
}
``

### GET /api/health
Health check del servidor.

**Response (200):**
``json
{
  \"status\": \"healthy\",
  \"timestamp\": \"2026-01-24T12:00:00Z\"
}
``

## Deployment

### Opci�n 1: IIS
1. Public� el proyecto: `dotnet publish -c Release`
2. Configur� IIS con el pool de aplicaciones para .NET Core
3. Configur� las variables de entorno en IIS

### Opci�n 2: Linux con Nginx
``bash
# Publicar
dotnet publish -c Release -o /var/www/contactapi

# Crear servicio systemd
sudo nano /etc/systemd/system/contactapi.service
``

### Opci�n 3: Docker
``dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT [\"dotnet\", \"ContactApi.dll\"]
``

## CORS

El API est� configurado para aceptar requests desde:
- `http://localhost:5173` (dev)
- `http://localhost:5174` (dev)
- `https://liberal-libertario.com`
- `https://www.liberal-libertario.com`

Si necesit�s agregar m�s dominios, edit� `Program.cs` en la secci�n `WithOrigins()`.

## Seguridad

-  HTTPS habilitado por defecto
-  CORS configurado
-  Validaci�n de inputs
-  Logging de errores
-  Configur� rate limiting en producci�n (recomendado)
