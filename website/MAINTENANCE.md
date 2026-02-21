# 🛠️ Modo Mantenimiento

Este documento explica cómo activar y desactivar el modo mantenimiento del sitio web.

## ¿Qué es el modo mantenimiento?

El modo mantenimiento es una funcionalidad que permite "parkear" el sitio temporalmente, mostrando una página elegante que informa a los visitantes que el sitio está en mantenimiento temporal. 

**Características:**
- Página limpia sin menú de navegación ni footer
- Ilustración vectorial moderna y profesional
- Mensaje claro y amigable
- Sin información de contacto para evitar interrupciones

Es útil cuando necesitas:

- Realizar actualizaciones importantes
- Solucionar problemas técnicos
- Implementar nuevas funcionalidades
- Cualquier trabajo que requiera que el sitio no esté disponible temporalmente

## 🚀 Cómo activar el modo mantenimiento

### Paso 1: Editar el archivo `.env`

1. Abre el archivo `.env` en la raíz del proyecto `website`
2. Busca la línea que dice: `VITE_MAINTENANCE_MODE=false`
3. Cámbiala a: `VITE_MAINTENANCE_MODE=true`

```env
VITE_MAINTENANCE_MODE=true
```

### Paso 2: Reiniciar el servidor (si está en desarrollo)

Si estás corriendo el servidor de desarrollo, debes reiniciarlo para que los cambios surtan efecto:

```bash
# Detén el servidor (Ctrl + C)
# Luego vuelve a iniciarlo
npm run dev
```

### Paso 3: Reconstruir para producción (si es necesario)

Si vas a desplegar los cambios a producción:

```bash
npm run build
```

¡Listo! Ahora el sitio mostrará la página de mantenimiento.

## ✅ Cómo desactivar el modo mantenimiento

### Paso 1: Editar el archivo `.env`

1. Abre el archivo `.env` en la raíz del proyecto `website`
2. Busca la línea que dice: `VITE_MAINTENANCE_MODE=true`
3. Cámbiala a: `VITE_MAINTENANCE_MODE=false`

```env
VITE_MAINTENANCE_MODE=false
```

### Paso 2: Reiniciar el servidor

Sigue los mismos pasos que para activar el modo mantenimiento:

```bash
# Detén el servidor (Ctrl + C)
# Luego vuelve a iniciarlo
npm run dev
```

### Paso 3: Reconstruir para producción (si es necesario)

```bash
npm run build
```

¡El sitio volverá a funcionar normalmente!

## 🎨 Personalización

### Cambiar el mensaje

Si deseas personalizar el mensaje de mantenimiento, edita el archivo:
`src/views/MaintenanceView.vue`

Busca las secciones con el texto y modifícalo según tus necesidades.

### Cambiar la imagen

La página de mantenimiento usa una ilustración vectorial SVG personalizada. Si deseas cambiarla:

1. Abre `src/views/MaintenanceView.vue`
2. Busca la sección `<svg class="illustration">`
3. Puedes:
   - Reemplazar todo el SVG con uno de [unDraw](https://undraw.co/) (gratuito y open source)
   - Usar una ilustración de [Storyset](https://storyset.com/) (también gratuito)
   - Crear tu propia ilustración SVG

### Cambiar los colores de la ilustración

Los colores de la ilustración usan las variables CSS del sitio:
- `#F2B400` - Color primario (amarillo)
- `#D9A200` - Color primario oscuro
- `#FFD54F` - Color primario claro

Puedes cambiarlos directamente en el SVG o usar las variables CSS del sitio.

## 📋 Checklist rápido

**Para activar:**
- [ ] Cambiar `.env`: `VITE_MAINTENANCE_MODE=true`
- [ ] Reiniciar servidor de desarrollo (si aplica)
- [ ] Rebuild para producción (si aplica)

**Para desactivar:**
- [ ] Cambiar `.env`: `VITE_MAINTENANCE_MODE=false`
- [ ] Reiniciar servidor de desarrollo (si aplica)
- [ ] Rebuild para producción (si aplica)

## ⚠️ Importante

- El modo mantenimiento se controla mediante una variable de entorno
- Los cambios en `.env` requieren reiniciar el servidor de desarrollo
- Para producción, siempre debes hacer un nuevo build después de cambiar la variable
- No olvides commitear el archivo `.env` si quieres mantener el estado en el repositorio (o usa `.env.production` para producción específicamente)

## 🆘 Solución de problemas

**El sitio no muestra la página de mantenimiento:**
- Verifica que cambiaste a `true` (en minúsculas, sin comillas)
- Asegúrate de haber reiniciado el servidor de desarrollo
- Limpia la caché del navegador (Ctrl + Shift + R)

**El sitio sigue mostrando la página de mantenimiento:**
- Verifica que cambiaste a `false` (en minúsculas, sin comillas)
- Reinicia el servidor de desarrollo
- Verifica que no tengas múltiples archivos `.env` en conflicto

---

**Creado:** Febrero 2026  
**Liberal Libertario**
