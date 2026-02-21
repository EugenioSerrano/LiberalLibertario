<script setup lang="ts">
import { RouterLink } from 'vue-router'
import PageHeader from '@/components/PageHeader.vue'
import StepsSection from '@/components/StepsSection.vue'
import ContactForm from '@/components/ContactForm.vue'

const steps = [
  {
    title: 'Conocé los principios',
    text: 'Queremos coherencia: primero leé y entendé qué defendemos.'
  },
  {
    title: 'Sumate al grupo',
    text: 'Participá con respeto, escuchá y aportá ideas.'
  },
  {
    title: 'Pasá a la acción',
    text: 'Ayudá a vigilar, proponer o formar. Hay lugar para todos.'
  }
]
</script>

<template>
  <div class="sumate">
    <PageHeader
      headline="Sumate a la defensa de la libertad"
      subheadline="Si compartís estos valores, este espacio también es tuyo."
    />

    <section class="section intro-section">
      <div class="container">
        <div class="intro-content">
          <h2>¿Por qué sumarte?</h2>
          <p>
            No buscamos cantidad, buscamos compromiso. Si creés en la libertad individual,
            en un Estado limitado y en la ética como forma de hacer política, este es tu lugar.
          </p>
          <p>
            No hace falta experiencia previa en política. Lo que pedimos es coherencia,
            respeto y ganas de trabajar por un cambio real.
          </p>
          <div class="intro-cta">
            <RouterLink to="/principios" class="btn btn-secondary">
              Leé nuestros principios
            </RouterLink>
          </div>
        </div>
      </div>
    </section>

    <StepsSection
      title="Cómo participar"
      :items="steps"
    />

    <ContactForm
      title="Contacto rápido"
      text="Dejá tu mensaje o escribinos por redes. Te respondemos y te contamos cómo sumarte."
    />

    <section class="section commitment-section">
      <div class="container">
        <div class="commitment-content">
          <h2>Nuestro compromiso con vos</h2>
          <ul class="commitment-list">
            <li>
              <span class="commitment-icon">✓</span>
              <span>Te escuchamos y valoramos tus ideas</span>
            </li>
            <li>
              <span class="commitment-icon">✓</span>
              <span>Trabajamos en equipo, sin caudillos ni jerárquías rígidas</span>
            </li>
            <li>
              <span class="commitment-icon">✓</span>
              <span>Respetamos tu tiempo y tu forma de participar</span>
            </li>
            <li>
              <span class="commitment-icon">✓</span>
              <span>Construimos un espacio libre de clientelismo y oportunismo</span>
            </li>
          </ul>
        </div>
      </div>
    </section>
  </div>
</template>

<style scoped>
.intro-section {
  background: var(--color-background);
}

.intro-content {
  max-width: 700px;
  margin: 0 auto;
  text-align: center;
}

.intro-content h2 {
  margin-bottom: 1.5rem;
}

.intro-content p {
  color: var(--color-text-light);
  font-size: 1.125rem;
  line-height: 1.8;
}

.intro-cta {
  margin-top: 2rem;
}

.commitment-section {
  background: linear-gradient(135deg, var(--color-text) 0%, #374151 100%);
}

.commitment-content {
  max-width: 700px;
  margin: 0 auto;
}

.commitment-content h2 {
  color: #FFFFFF;
  text-align: center;
  margin-bottom: 2rem;
}

.commitment-list {
  list-style: none;
  padding: 0;
  margin: 0;
}

.commitment-list li {
  display: flex;
  align-items: flex-start;
  gap: 1rem;
  padding: 1rem 0;
  border-bottom: 1px solid rgba(255, 255, 255, 0.1);
  color: #D1D5DB;
  font-size: 1.125rem;
}

.commitment-list li:last-child {
  border-bottom: none;
}

.commitment-icon {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 28px;
  height: 28px;
  background: var(--color-primary);
  color: var(--color-text);
  font-weight: 700;
  border-radius: 50%;
  flex-shrink: 0;
}
</style>