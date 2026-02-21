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
            alt="Libertarios Traslasierra" 
            class="logo"
          />
          <h1 class="logo-text">Libertarios Traslasierra</h1>
        </div>

        <!-- Imagen de ilustración -->
        <div class="illustration-section">
          <img 
            src="https://images.unsplash.com/photo-1584432810601-6c7f27d2362b?w=1200&h=600&fit=crop&q=80" 
            alt="Fin de un camino" 
            class="illustration"
          />
        </div>

        <!-- Mensaje principal -->
        <div class="message-section">
          <h2 class="headline">Libertarios Traslasierra ha dejado de existir.</h2>
          
          <div class="comunicado">
            <p class="statement">
              Se acordó trabajar por mayoría, con reglas claras y diálogo.<br>
              No se cumplió.
            </p>
            
            <p class="statement">
              Unos pocos decidieron imponer su voluntad y dinamitar lo que se había construido.
            </p>
            
            <p class="statement">
              Lamentamos el papelón público y pedimos disculpas a quienes confiaron en este espacio.
            </p>
            
            <p class="statement final">
              Queda demostrado que sin respeto por los acuerdos y con egos descontrolados, ninguna idea, por buena que sea, puede prosperar.
            </p>
            
            <p class="closure">
              Fin del comunicado.
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
  background: linear-gradient(135deg, #2C2C2C 0%, #1a1a1a 100%);
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
  border-bottom: 3px solid #1a1a1a;
  opacity: 0.6;
}

.logo {
  height: 80px;
  width: auto;
  filter: grayscale(100%);
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
  border-left-color: #1a1a1a;
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
  filter: grayscale(50%) brightness(0.8);
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
