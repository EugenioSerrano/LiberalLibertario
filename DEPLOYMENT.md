# Deployment Guide - Liberal Libertario

## Arquitectura

```
Frontend (Vue.js) → Cloudflare Pages
      ↓ API calls (HTTPS)
Backend (.NET 10) → Tu servidor (puerto 80/443)
      ↓ SMTP
Email Server → Gmail
```

## 1. Backend API (.NET 10)

### Paso 1: Configurar credenciales de email

Creá el archivo `api/appsettings.Local.json` con tus credenciales reales:

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
    "SmtpUser": "libertariostraslasierra@gmail.com",
    "SmtpPassword": "tu-password-de-aplicacion",
    "ToEmail": "contacto@libertarios-traslasierra.org"
  }
}
```

**Para Gmail:**
1. Primero, **activá la verificación en dos pasos:**
   - Andá a: https://myaccount.google.com/signinoptions/two-step-verification
   - Clic en "Comenzar" o "Get Started"
   - Seguí los pasos para configurar tu teléfono
   
2. Después de activar 2FA, **creá una contraseña de aplicación:**
   - Andá a: https://myaccount.google.com/apppasswords
   - Seleccioná "Correo" y el dispositivo "Otro (nombre personalizado)"
   - Poné "ContactAPI" como nombre
   - Copiá la contraseña de 16 caracteres que te da
   - Usá esa contraseña en `SmtpPassword`

**Alternativa si no podés usar Gmail:**
Si tu cuenta es de una organización o escuela, puede que no te permita contraseñas de aplicación. Alternativas:
- Usá una cuenta de Gmail personal
- Usá otro proveedor SMTP como:
  - **SendGrid** (gratis hasta 100 emails/día)
  - **Mailgun** (gratis hasta 5000 emails/mes)
  - **Brevo (ex Sendinblue)** (gratis hasta 300 emails/día)

### Paso 2: Publicar el proyecto

```powershell
cd api
dotnet publish -c Release -o ./publish
```

**IMPORTANTE:** Copiá manualmente el archivo `appsettings.Local.json` a la carpeta `publish/` en tu servidor.

### Paso 3: Deploy en tu servidor

**Opción A: Ejecutar como servicio con NSSM (recomendado)**

1. Descargá NSSM: https://nssm.cc/download
2. Instalá el servicio:

``powershell
nssm install ContactApiService \"C:\ruta\a\publish\ContactApi.exe\"
nssm set ContactApiService AppDirectory \"C:\ruta\a\publish\"
nssm set ContactApiService AppEnvironmentExtra Email__SmtpHost=smtp.gmail.com Email__SmtpPort=587
nssm start ContactApiService
``

**Opción B: Ejecutar con sc.exe**

``powershell
sc.exe create ContactApiService binPath=\"C:\ruta\a\publish\ContactApi.exe\" start=auto
sc.exe start ContactApiService
``

**Opción C: Ejecutar manualmente (solo para testing)**

``powershell
cd publish
.\ContactApi.exe
``

### Paso 5: Configurar Firewall

``powershell
New-NetFirewallRule -DisplayName \"Contact API HTTP\" -Direction Inbound -LocalPort 80 -Protocol TCP -Action Allow
New-NetFirewallRule -DisplayName \"Contact API HTTPS\" -Direction Inbound -LocalPort 443 -Protocol TCP -Action Allow
``

### Paso 6: Verificar que funciona

Desde tu navegador:
- http://tu-servidor-ip:5000/api/health (si usás puerto por defecto)
- http://tu-servidor-ip/api/health (si configuraste puerto 80)

Deberías ver: `{"status":"healthy","timestamp":"..."}`

---

## 2. Frontend (Vue.js)

### Paso 1: Build para producción

``bash
cd website
npm run b4: Configurar puerto 80/443 (opcional)

Si querés que la API corra en puerto 80 y 443, creá o editá `appsettings.Production.json` en tu servidor:

```json
{
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://*:80"
      },
      "Https": {
        "Url": "https://*:443",
        "Certificate"cd website && npm run build`
   - Build output directory: `website/dist`

3. **Variables de entorno:**
   - Nombre: `VITE_API_URL`
   - Valor: `http://tu-servidor-ip:5000` (o la URL/puerto que uses
  }
}
```

### Paso uild
``

Esto genera la carpeta `dist/` con los archivos estáticos.

### Paso 2: Deploy en Cloudflare Pages

1. **Ir a Cloudflare Dashboard**
   - Pages  Create a project  Connect to Git
   - Seleccioná tu repositorio

2. **Configuración del build:**
   - Framework preset: `Vue`
   - Build command: `npm run build`
   - Build output directory: `dist`
   - Root directory: `website`

3. **Variables de entorno:**
   - `VITE_API_URL` = `https://tu-servidor.com` (o IP de tu servidor)

4. **Deploy:**
   - Cloudflare automáticamente hace deploy cuando hacés push

### Paso 3: Configurar dominio

1. En Cloudflare Pages  Custom domains
2. Agregá `liberal-libertario.com`
3. Cloudflare configura automáticamente DNS y HTTPS

---

## 3. Archivo de configuración en el servidor

Una vez que tengas todo deployado, tu estructura en el servidor debería verse así:

```
/ruta/a/publish/
  ├── ContactApi.exe
  ├── appsettings.json          (del repo, sin credenciales)
  ├── appsettings.Local.json    (copiado manualmente, CON credenciales)
  ├── appsettings.Production.json (opcional, para puerto 80/443)
  └── ... (otros archivos del publish)
```

---

## 4. Actualizar CORS

Una vez que sepas la URL final de tu servidor, actualizá `api/Program.cs`:

``csharp
policy.WithOrigins(
   5\"http://localhost:5173\",
    \"http://localhost:5174\", 
    "https://liberal-libertario.com",
    "https://www.liberal-libertario.com"
)
``

Volvé a publicar:
``powershell
cd api
dotnet publish -c Release -o ./publish
``

---

## 4. Testing

### Test local

Terminal 1 - Backend:
``powershell
cd api
dotnet run
``

Terminal 2 - Frontend:
``p6wershell
cd website
npm run dev
``

Probá el formulario en: http://localhost:5174/contacto

### Test producción

1. Health check: `https://tu-servidor/api/health`
2. Probá el formulario en tu sitio
3. Verificá que llegue el email
que `appsettings.Local.json` esté en la carpeta de publish
- Para Gmail, usá contraseña de aplicación (no tu contraseña normal)
- Revisá los logs del servicio

### Variables de entorno no funcionan
- Recordá que ahora usamos archivos de configuración, no variables de entorno
- El orden de carga es: appsettings.json → appsettings.Development.json → appsettings.Local.json
## 5. Troubleshooting

### La app no arranca en puerto 80/443
- Verificá que no haya otra app usando esos puertos
- Ejecutá PowerShell como Administrador
- En Windows, el puerto 80 puede estar usado por IIS

### Error de CORS
- Verificá que el dominio esté en `WithOrigins()`
- Recordá recompilar y republicar después de cambios

### Emails no se envían
- Verificá credenciales en `appsettings.json`
- Para Gmail, usá contraseña de aplicación (no tu contraseña normal)
- Revisá los logs del servicio

### Ver logs del servicio

``powershell
# Con NSSM
nssm status ContactApiService

# Logs de eventos de Windows
Get-EventLog -LogName Application -Source ContactApiService -Newest 50
``

---

## Costos

- **Frontend (Cloudflare Pages):** GRATIS
- **Dominio:** ~\-15/año
- **Servidor:** Variable (tu propio servidor)
- **Email:** GRATIS (Gmail)

**Total estimado: \-15/año** (solo el dominio)
