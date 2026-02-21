<script setup lang="ts">
import PageHeader from '@/components/PageHeader.vue'
import PrinciplesList from '@/components/PrinciplesList.vue'
import ValuesGrid from '@/components/ValuesGrid.vue'

const principles = [
  {
    key: 'libertad_individual',
    title: 'Libertad individual',
    bullets: [
      'Defendemos la libertad de pensamiento, expresión, trabajo y asociación.',
      'El individuo es anterior al Estado y no un medio para fines políticos.',
      'Rechazamos toda forma de autoritarismo, venga de donde venga.'
    ]
  },
  {
    key: 'estado_limitado',
    title: 'Estado limitado, eficiente y transparente',
    bullets: [
      'El Estado debe cumplir funciones esenciales, no invadir la vida privada.',
      'Promovemos la reducción del gasto innecesario y el uso responsable de recursos públicos.',
      'La transparencia no es un slogan: es una obligación ética.'
    ]
  },
  {
    key: 'igualdad_ley',
    title: 'Igualdad ante la ley',
    bullets: [
      'Rechazamos privilegios políticos, sindicales, empresariales o corporativos.',
      'La ley debe aplicarse igual para todos, sin excepciones.',
      'No creemos en ciudadanos de primera y de segunda.'
    ]
  },
  {
    key: 'trabajo_responsabilidad',
    title: 'Cultura del trabajo y la responsabilidad',
    bullets: [
      'El progreso surge del trabajo, el mérito y el esfuerzo.',
      'El asistencialismo permanente destruye dignidad y futuro.',
      'Las políticas sociales deben ser transitorias, focalizadas y orientadas a la autonomía.'
    ]
  },
  {
    key: 'propiedad_privada',
    title: 'Propiedad privada',
    bullets: [
      'Es un pilar de la libertad y del desarrollo.',
      'Sin reglas claras y respeto por lo ajeno, no hay inversión ni crecimiento.',
      'Defendemos la seguridad jurídica como condición básica.'
    ]
  }
]

const formsValues = [
  {
    title: 'Ética y coherencia',
    description: 'Rechazamos prácticas clientelares, oportunistas o deshonestas.'
  },
  {
    title: 'Respeto y diálogo',
    description: 'Debate firme pero respetuoso. No insultamos ni degradamos al que piensa distinto.'
  },
  {
    title: 'Independencia personal',
    description: 'Ningún integrante habla en nombre del grupo sin consenso. Lealtad a principios.'
  }
]
</script>

<template>
  <div class="principios">
    <PageHeader
      headline="Qué defendemos"
      subheadline="Respeto irrestricto al proyecto de vida del prójimo, responsabilidad individual y Estado limitado."
    />

    <PrinciplesList
      intro="Nuestro compromiso es con los principios. Las personas son vehículos de esas ideas, pero la lealtad es a los valores."
      :items="principles"
    />

    <section class="section callout-section">
      <div class="container">
        <div class="callout-box">
          <h2 class="callout-title">Valores y formas</h2>
          <p class="callout-subtitle">Esto es clave</p>
        </div>
      </div>
    </section>

    <ValuesGrid :items="formsValues" />
  </div>
</template>

<style scoped>
.callout-section {
  background: var(--color-background-alt);
  padding: 3rem 0;
}

.callout-box {
  text-align: center;
}

.callout-title {
  margin-bottom: 0.5rem;
}

.callout-subtitle {
  color: var(--color-primary-dark);
  font-weight: 600;
  font-size: 1.125rem;
  margin: 0;
}
</style>