<script setup lang="ts">
import { RouterLink } from 'vue-router'
import HeroSection from '@/components/HeroSection.vue'
import FeatureCards from '@/components/FeatureCards.vue'
import QuoteSection from '@/components/QuoteSection.vue'
import CalloutSection from '@/components/CalloutSection.vue'
import GallerySection from '@/components/GallerySection.vue'
</script>

<template>
  <div class="home">
    <HeroSection
      eyebrow="Traslasierra · Córdoba"
      headline="Una idea de libertad que echó raíces en Traslasierra"
      subheadline="Somos un grupo de vecinos, trabajadores, emprendedores, productores, docentes y estudiantes independientes y libre-pensadores que decidimos organizarnos para defender ideas, no cargos. Creemos en la libertad, la responsabilidad individual y un Estado limitado, eficiente y transparente."
    >
      <template #cta>
        <RouterLink to="/sumate" class="btn btn-primary">Sumate</RouterLink>
        <RouterLink to="/principios" class="btn btn-secondary">Conocé nuestros principios</RouterLink>
      </template>
    </HeroSection>

    <FeatureCards
      title="Nuestro plan se construye sobre tres pilares"
      :items="[
        { 
          title: 'Vigilar', 
          description: 'Ser los ojos de los ciudadanos: auditar, controlar y exponer abusos.',
          icon: '👁️'
        },
        { 
          title: 'Proponer', 
          description: 'Convertir la crítica en soluciones concretas, con objetivos claros.',
          icon: '💡'
        },
        { 
          title: 'Formar', 
          description: 'Preparar personas y equipos para sostener el cambio en el tiempo.',
          icon: '🎓'
        }
      ]"
    />

    <QuoteSection
      quote="Nuestra lealtad es a los principios, no a personas."
      note="Ideas por encima de las personas. Coherencia por encima del oportunismo."
    />

    <GallerySection />

    <CalloutSection
      title="El objetivo es un cambio cultural"
      text="No se trata solo de una elección. Se trata de sostener una cultura de libertad, responsabilidad y respeto en nuestra comunidad."
      ctaLabel="Cómo trabajamos"
      ctaHref="/como-trabajamos"
    />
  </div>
</template>

<style scoped>
.home {
  overflow-x: hidden;
}
</style>
