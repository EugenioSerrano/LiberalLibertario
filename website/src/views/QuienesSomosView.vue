<script setup lang="ts">
import PageHeader from '@/components/PageHeader.vue'
import ValuesGrid from '@/components/ValuesGrid.vue'

const values = [
  { 
    title: 'Ética y coherencia', 
    description: 'Los medios importan tanto como los fines. No todo vale para ganar.'
  },
  { 
    title: 'Respeto y diálogo', 
    description: 'Debate firme, sin insultos ni difamación. La violencia verbal empobrece.'
  },
  { 
    title: 'Independencia', 
    description: 'No pertenecemos a ninguna estructura partidaria tradicional. Libertad de criterio y acción.'
  }
]
</script>

<template>
  <div class="quienes-somos">
    <PageHeader
      headline="Gente común. Ideas firmes."
      subheadline="Venimos de afuera de la política tradicional. Nos une la necesidad de un cambio real, no la búsqueda de un cargo."
    />

    <section class="section content-section">
      <div class="container">
        <div class="infografia-container">
          <picture>
            <!-- Imagen vertical para mobile -->
            <source 
              media="(max-width: 768px)" 
              srcset="@/assets/Infografia-QuienesSomos-Vertical.png"
            />
            <!-- Imagen horizontal para desktop -->
            <img 
              src="@/assets/Infografia-QuienesSomos.png" 
              alt="Quiénes somos - Infografía"
              class="infografia"
            />
          </picture>
        </div>
      </div>
    </section>

    <ValuesGrid 
      title="Lo que nos define"
      :items="values"
    />
  </div>
</template>

<style scoped>
.content-section {
  background: var(--color-background);
  padding: 3rem 0;
}

.infografia-container {
  max-width: 1400px;
  margin: 0 auto;
  padding: 0 1rem;
}

.infografia {
  width: 100%;
  height: auto;
  border-radius: 16px;
  box-shadow: 0 8px 40px rgba(0, 0, 0, 0.15);
  display: block;
}

@media (max-width: 768px) {
  .content-section {
    padding: 2rem 0;
  }
  
  .infografia-container {
    padding: 0 0.5rem;
  }
}
</style>