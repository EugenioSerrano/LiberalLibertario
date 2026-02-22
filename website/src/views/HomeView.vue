<script setup lang="ts">
import { RouterLink } from 'vue-router'
import HeroSection from '@/components/HeroSection.vue'
import FeatureCards from '@/components/FeatureCards.vue'
import QuoteSection from '@/components/QuoteSection.vue'
import CalloutSection from '@/components/CalloutSection.vue'
</script>

<template>
  <div class="home">
    <HeroSection
      eyebrow="Liberal · Libertario"
      headline="Un espacio para las ideas de libertad"
      subheadline="Profesional independiente, libre-pensador. Creo en la libertad individual, la responsabilidad personal y un Estado limitado. Aquí comparto principios, recursos y reflexiones sobre cómo vivir en libertad."
    >
      <template #cta>
        <RouterLink to="/principios" class="btn btn-primary">Conocé los principios</RouterLink>
        <RouterLink to="/aprendamos-juntos" class="btn btn-secondary">Biblioteca</RouterLink>
      </template>
    </HeroSection>

    <FeatureCards
      title="Pilares fundamentales"
      :items="[
        { 
          title: 'Libertad Individual', 
          description: 'Defensa irrestricta de tu derecho a pensar, expresarte y vivir según tus propias decisiones.',
          icon: 'person-running'
        },
        { 
          title: 'Responsabilidad Personal', 
          description: 'El individuo como dueño de sus decisiones y consecuencias. Sin paternalismos ni excusas.',
          icon: 'balance-scale'
        },
        { 
          title: 'Estado Limitado', 
          description: 'Un Estado eficiente, transparente y acotado a sus funciones esenciales.',
          icon: 'landmark'
        }
      ]"
    />

    <QuoteSection
      quote="La lealtad debe ser a los principios, no a personas."
      note="Ideas por encima de las personas. Coherencia por encima del oportunismo."
    />

    <CalloutSection
      title="Aprendé sobre libertad"
      text="Descubrí una biblioteca curada de audiolibros y recursos esenciales para entender las ideas liberales."
      ctaLabel="Explorar biblioteca"
      ctaHref="/aprendamos-juntos"
    />
  </div>
</template>

<style scoped>
.home {
  overflow-x: hidden;
}
</style>
