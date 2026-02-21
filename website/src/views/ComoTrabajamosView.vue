<script setup lang="ts">
import PageHeader from '@/components/PageHeader.vue'
import QuoteSection from '@/components/QuoteSection.vue'

const workPrinciples = [
  {
    icon: '🤝',
    title: 'Horizontalidad',
    description: 'Creemos en la fuerza del grupo organizado, no en el liderazgo de un solo caudillo.'
  },
  {
    icon: '💬',
    title: 'Debate respetuoso',
    description: 'Nos cuidamos en las formas: debate firme, sin agresiones, sin difamación y sin violencia verbal.'
  },
  {
    icon: '🎯',
    title: 'Construcción limpia',
    description: 'Rechazamos clientelismo, oportunismo y atajos. Preferimos construir lento, pero limpio.'
  }
]
</script>

<template>
  <div class="como-trabajamos">
    <PageHeader
      headline="Horizontalidad, ética y coherencia"
      subheadline="Construimos desde la base: cada voz importa."
    />

    <section class="section principles-section">
      <div class="container">
        <div class="principles-grid">
          <article 
            v-for="(principle, index) in workPrinciples" 
            :key="index" 
            class="principle-card"
          >
            <span class="principle-icon">{{ principle.icon }}</span>
            <h3>{{ principle.title }}</h3>
            <p>{{ principle.description }}</p>
          </article>
        </div>
      </div>
    </section>

    <QuoteSection
      quote="El objetivo es un cambio cultural, no solo ganar una elección."
      note="Si hay condiciones para presentar candidatos, lo haremos. Y si no, seguimos igual."
    />

    <section class="section method-section">
      <div class="container">
        <div class="method-content">
          <h2>Nuestra forma de trabajar</h2>
          <div class="method-grid">
            <div class="method-item">
              <h3>Reuniones abiertas</h3>
              <p>
                Nos juntamos periódicamente para discutir temas, proponer acciones y tomar
                decisiones en conjunto. Todos pueden participar.
              </p>
            </div>
            <div class="method-item">
              <h3>Decisiones consensuadas</h3>
              <p>
                Buscamos el consenso antes de actuar. Nadie habla en nombre del grupo sin
                el acuerdo de los demás.
              </p>
            </div>
            <div class="method-item">
              <h3>Comunicación transparente</h3>
              <p>
                Lo que hacemos es público. Nuestras acciones, posiciones y decisiones
                están disponibles para quien quiera conocerlas.
              </p>
            </div>
            <div class="method-item">
              <h3>Formación continua</h3>
              <p>
                Estudiamos, aprendemos y compartimos conocimiento sobre economía,
                historia, derecho y política.
              </p>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<style scoped>
.principles-section {
  background: var(--color-background);
}

.principles-grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 2rem;
}

.principle-card {
  background: var(--color-background-alt);
  padding: 2.5rem;
  border-radius: 16px;
  text-align: center;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.05);
  border: 1px solid var(--color-border);
}

.principle-icon {
  display: inline-block;
  font-size: 3rem;
  margin-bottom: 1.25rem;
}

.principle-card h3 {
  font-size: 1.25rem;
  margin-bottom: 0.75rem;
  color: var(--color-text);
}

.principle-card p {
  color: var(--color-muted);
  margin: 0;
  line-height: 1.7;
}

.method-section {
  background: var(--color-background-alt);
}

.method-content h2 {
  text-align: center;
  margin-bottom: 3rem;
}

.method-grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 2rem;
}

.method-item {
  background: var(--color-background);
  padding: 2rem;
  border-radius: 12px;
  border-left: 4px solid var(--color-primary);
}

.method-item h3 {
  font-size: 1.125rem;
  margin-bottom: 0.75rem;
  color: var(--color-text);
}

.method-item p {
  color: var(--color-muted);
  margin: 0;
  line-height: 1.7;
}

@media (max-width: 1024px) {
  .principles-grid {
    grid-template-columns: 1fr;
    max-width: 500px;
    margin: 0 auto;
  }
}

@media (max-width: 768px) {
  .method-grid {
    grid-template-columns: 1fr;
  }
}
</style>