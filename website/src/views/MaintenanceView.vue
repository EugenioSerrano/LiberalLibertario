<script setup lang="ts">
// Componente de página de mantenimiento
</script>

<template>
  <div class="maintenance-page">
    <div class="maintenance-container">
      <div class="maintenance-content">
        <!-- Logo -->
        <div class="logo-section">
          <img 
            src="@/assets/LogoCondorOriginal.png" 
            alt="Liberal Libertario" 
            class="logo"
          />
          <h1 class="logo-text">Liberal Libertario</h1>
        </div>

        <!-- Imagen de ilustración -->
        <div class="illustration-section">
          <img 
            src="https://images.unsplash.com/photo-1497215842964-222b430dc094?w=1200&h=600&fit=crop&q=80" 
            alt="Trabajo en progreso" 
            class="illustration"
          />
        </div>

        <!-- Mensaje principal -->
        <div class="message-section">
          <h2 class="headline">Estamos trabajando en algo nuevo</h2>
          
          <div class="comunicado">
            <p class="statement">
              Liberal Libertario está dando sus primeros pasos.<br>
              Estamos construyendo un espacio coherente y ético para las ideas de libertad.
            </p>
            
            <p class="statement">
              Próximamente tendremos novedades sobre quiénes somos, qué hacemos y cómo sumarse.
            </p>
            
            <p class="statement final">
              Mientras tanto, estamos trabajando en los detalles para ofrecerte la mejor experiencia.
            </p>
            
            <p class="closure">
              Volvemos pronto.
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.maintenance-page {
  min-height: 100vh;
  background: linear-gradient(135deg, var(--color-primary) 0%, var(--color-primary-dark) 100%);
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 2rem;
}

.maintenance-container {
  max-width: 900px;
  width: 100%;
  margin: 0 auto;
}

.maintenance-content {
  background: #ffffff;
  border-radius: 1rem;
  box-shadow: 0 10px 50px rgba(0, 0, 0, 0.5);
  padding: 3rem 2rem;
  text-align: center;
  border: 1px solid #333;
}

.logo-section {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 1rem;
  margin-bottom: 2.5rem;
  padding-bottom: 2rem;
  border-bottom: 3px solid var(--color-primary);
}

.logo {
  height: 80px;
  width: auto;
}

.logo-text {
  font-family: var(--font-heading);
  font-size: clamp(1.5rem, 4vw, 2rem);
  font-weight: 700;
  color: var(--color-text);
  margin: 0;
}

.message-section {
  margin-bottom: 2.5rem;
}

.headline {
  font-family: var(--font-heading);
  font-size: clamp(1.75rem, 5vw, 2.5rem);
  font-weight: 700;
  color: #1a1a1a;
  margin-bottom: 2rem;
  line-height: 1.2;
}

.comunicado {
  max-width: 700px;
  margin: 0 auto;
  text-align: left;
}

.statement {
  font-size: clamp(1rem, 2.5vw, 1.15rem);
  color: #333;
  line-height: 1.8;
  margin-bottom: 1.5rem;
  padding: 1rem;
  background: #f8f8f8;
  border-left: 4px solid #666;
}

.statement.final {
  font-weight: 600;
  border-left-color: var(--color-primary);
  background: #f0f0f0;
}

.closure {
  font-size: 1.1rem;
  color: #666;
  font-style: italic;
  margin-top: 2rem;
  font-weight: 600;
  text-align: center;
}

.illustration-section {
  margin: 0 0 2.5rem 0;
  padding: 0;
  display: flex;
  justify-content: center;
  align-items: center;
  overflow: hidden;
  border-radius: 0.5rem;
}

.illustration {
  width: 100%;
  max-width: 100%;
  height: auto;
  max-height: 300px;
  object-fit: cover;
  border-radius: 0.5rem;
}

/* Responsive */
@media (max-width: 768px) {
  .maintenance-content {
    padding: 2rem 1.5rem;
  }
  
  .logo {
    height: 60px;
  }
  
  .illustration {
    max-width: 100%;
  }
  
  .illustration-section {
    padding: 1rem;
  }
}

@media (max-width: 480px) {
  .maintenance-page {
    padding: 1rem;
  }
  
  .maintenance-content {
    padding: 1.5rem 1rem;
  }
  
  .logo-section {
    margin-bottom: 1.5rem;
    padding-bottom: 1.5rem;
  }
}
</style>
