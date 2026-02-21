<script setup lang="ts">
import PageHeader from '@/components/PageHeader.vue'
import TimelineSection from '@/components/TimelineSection.vue'

const timelineItems = [
  {
    title: 'Ciudadanos inspirados por la libertad',
    text: 'Empezamos como vecinos y trabajadores, sin experiencia política previa, buscando un cambio real.'
  },
  {
    title: 'Acción inicial: fiscalizar y defender el voto',
    text: 'Nos organizamos espontáneamente para fiscalizar elecciones, aun con pocos recursos.'
  },
  {
    title: 'Cambio de paradigma',
    text: 'Decidimos romper con el statu quo, el clientelismo y las prácticas de siempre.'
  },
  {
    title: 'Construcción local a largo plazo',
    text: 'Entendimos que la transformación se sostiene en el tiempo, con ideas claras y trabajo constante.'
  }
]
</script>

<template>
  <div class="origen">
    <PageHeader
      headline="De seguir una idea a defenderla en las urnas"
      subheadline="Pasamos de compartir ideas a organizarnos para cuidar el voto y actuar."
    />

    <TimelineSection :items="timelineItems" />

    <section class="section journey-section">
      <div class="container">
        <div class="journey-content">
          <h2>El camino continúa</h2>
          <p>
            No somos políticos de carrera. Somos vecinos que decidimos dejar de quejarnos y empezar a hacer.
            Nuestra historia recién comienza, y cada paso que damos está guiado por los mismos principios
            que nos unieron desde el primer día.
          </p>
          <p>
            La libertad no se regala: se construye día a día, con trabajo, coherencia y compromiso.
          </p>
        </div>
      </div>
    </section>
  </div>
</template>

<style scoped>
.journey-section {
  background: var(--color-background-alt);
}

.journey-content {
  max-width: 700px;
  margin: 0 auto;
  text-align: center;
}

.journey-content h2 {
  margin-bottom: 1.5rem;
}

.journey-content p {
  color: var(--color-text-light);
  font-size: 1.125rem;
  line-height: 1.8;
}
</style>