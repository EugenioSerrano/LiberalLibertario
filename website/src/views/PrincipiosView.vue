<script setup lang="ts">
import PageHeader from '@/components/PageHeader.vue'
import PrinciplesList from '@/components/PrinciplesList.vue'
import ValuesGrid from '@/components/ValuesGrid.vue'

const principles = [
  {
    key: 'libertad_individual',
    title: 'Libertad individual',
    bullets: [
      'Defiendo la libertad de pensamiento, expresión, trabajo y asociación.',
      'El individuo es anterior al Estado y no un medio para fines políticos.',
      'Rechazo toda forma de autoritarismo, venga de donde venga.'
    ]
  },
  {
    key: 'estado_limitado',
    title: 'Estado limitado, eficiente y transparente',
    bullets: [
      'El Estado debe cumplir funciones esenciales, no invadir la vida privada.',
      'Promuevo la reducción del gasto innecesario y el uso responsable de recursos públicos.',
      'La transparencia no es un slogan: es una obligación ética.'
    ]
  },
  {
    key: 'igualdad_ley',
    title: 'Igualdad ante la ley',
    bullets: [
      'Rechazo privilegios políticos, sindicales, empresariales o corporativos.',
      'La ley debe aplicarse igual para todos, sin excepciones.',
      'No creo en ciudadanos de primera y de segunda.'
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
      'Defiendo la seguridad jurídica como condición básica.'
    ]
  },
  {
    key: 'libre_mercado',
    title: 'Libre mercado y libertad económica',
    bullets: [
      'El intercambio voluntario es motor de progreso y cooperación.',
      'Rechazo el proteccionismo, los monopolios estatales y las trabas burocráticas.',
      'La competencia beneficia al consumidor y estimula la innovación.'
    ]
  },
  {
    key: 'descentralizacion',
    title: 'Descentralización del poder',
    bullets: [
      'Cuanto más cerca esté el poder de la gente, mejor.',
      'Defiendo el federalismo real y la autonomía municipal.',
      'Concentrar el poder es peligroso, descentralizarlo es saludable.'
    ]
  },
  {
    key: 'educacion_critica',
    title: 'Educación y pensamiento crítico',
    bullets: [
      'Una ciudadanía informada es la mejor defensa de la libertad.',
      'Promuevo el acceso al conocimiento, el debate de ideas y la lectura.',
      'Rechazo el adoctrinamiento y defiendo la pluralidad de pensamiento.'
    ]
  },
  {
    key: 'no_agresion',
    title: 'Principio de no agresión',
    bullets: [
      'Nadie tiene derecho a iniciar violencia contra otro.',
      'La defensa es legítima, la agresión no.',
      'Este principio se aplica tanto a individuos como al Estado.'
    ]
  }
]

const formsValues = [
  {
    title: 'Ética y coherencia',
    description: 'Rechazo prácticas clientelares, oportunistas o deshonestas.'
  },
  {
    title: 'Respeto y diálogo',
    description: 'Debate firme pero respetuoso. Sin insultos ni degradación al que piensa distinto.'
  },
  {
    title: 'Independencia intelectual',
    description: 'Lealtad a los principios, no a personas o partidos.'
  }
]
</script>

<template>
  <div class="principios">
    <PageHeader
      headline="Qué defiendo"
      subheadline="Respeto irrestricto al proyecto de vida del prójimo, responsabilidad individual y Estado limitado."
    />

    <PrinciplesList
      intro="Mi compromiso es con los principios. Las personas son vehículos de esas ideas, pero la lealtad es a los valores."
      :items="principles"
    />

    <section class="section callout-section">
      <div class="container">
        <div class="callout-box">
          <h2 class="callout-title">Valores en la práctica</h2>
          <p class="callout-subtitle">Cómo lo llevo a cabo</p>
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