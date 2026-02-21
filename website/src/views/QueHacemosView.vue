<script setup lang="ts">
import PageHeader from '@/components/PageHeader.vue'
import ThreeColumns from '@/components/ThreeColumns.vue'

const pillars = [
  {
    title: 'Pilar 1: Vigilar el poder',
    bullets: [
      'Auditar: analizar en qué se gasta el dinero del municipio.',
      'Controlar: fiscalizar acciones del Estado para evitar abusos.',
      'Exponer: terminar con clientelismo y política de dádivas.'
    ]
  },
  {
    title: 'Pilar 2: Construir un plan concreto',
    bullets: [
      'Estrategia: metas a corto, mediano y largo plazo.',
      'Propuestas: soluciones reales a problemas locales.',
      'Acción: pasar de la charla a hechos concretos.'
    ]
  },
  {
    title: 'Pilar 3: Formar a nuestra gente',
    bullets: [
      'Expandir ideas: llevar principios de libertad a cada rincón.',
      'Preparar cuadros: formar futuros defensores en la gestión pública.',
      'Crecer en red: fomentar espacios donde todos propongan y sean escuchados.'
    ]
  }
]
</script>

<template>
  <div class="que-hacemos">
    <PageHeader
      headline="Del discurso a los hechos"
      subheadline="No nos quedamos en la crítica: trabajamos con un plan concreto."
    />

    <ThreeColumns :columns="pillars" />

    <section class="section action-section">
      <div class="container">
        <div class="action-content">
          <h2>No es solo hablar, es hacer</h2>
          <p>
            Cada semana trabajamos en acciones concretas. Pedimos información pública, analizamos
            presupuestos, fiscalizamos elecciones, formamos a nuevos integrantes y proponemos
            soluciones a problemas reales de nuestra comunidad.
          </p>
          <div class="action-stats">
            <div class="stat">
              <span class="stat-number">3</span>
              <span class="stat-label">Pilares de acción</span>
            </div>
            <div class="stat">
              <span class="stat-number">∞</span>
              <span class="stat-label">Compromiso</span>
            </div>
            <div class="stat">
              <span class="stat-number">1</span>
              <span class="stat-label">Objetivo: la libertad</span>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<style scoped>
.action-section {
  background: linear-gradient(135deg, var(--color-text) 0%, #374151 100%);
}

.action-content {
  max-width: 800px;
  margin: 0 auto;
  text-align: center;
}

.action-content h2 {
  color: #FFFFFF;
  margin-bottom: 1.5rem;
}

.action-content p {
  color: #D1D5DB;
  font-size: 1.125rem;
  line-height: 1.8;
  margin-bottom: 3rem;
}

.action-stats {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 2rem;
}

.stat {
  text-align: center;
}

.stat-number {
  display: block;
  font-family: var(--font-heading);
  font-size: 3rem;
  font-weight: 800;
  color: var(--color-primary);
  line-height: 1;
  margin-bottom: 0.5rem;
}

.stat-label {
  font-size: 0.875rem;
  color: #9CA3AF;
  text-transform: uppercase;
  letter-spacing: 0.05em;
}

@media (max-width: 640px) {
  .action-stats {
    grid-template-columns: 1fr;
    gap: 1.5rem;
  }

  .stat-number {
    font-size: 2.5rem;
  }
}
</style>