<script setup lang="ts">
interface StepItem {
  title: string
  text: string
}

defineProps<{
  title?: string
  items: StepItem[]
}>()
</script>

<template>
  <section class="section steps-section">
    <div class="container">
      <h2 v-if="title" class="steps-title">{{ title }}</h2>
      <div class="steps-grid">
        <div v-for="(item, index) in items" :key="index" class="step-card">
          <div class="step-badge">Paso {{ index + 1 }}</div>
          <h3 class="step-card-title">{{ item.title }}</h3>
          <p class="step-text">{{ item.text }}</p>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
.steps-section {
  background: var(--color-background);
}

.steps-title {
  text-align: center;
  margin-bottom: 3rem;
}

.steps-grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 2rem;
  position: relative;
}

.steps-grid::before {
  content: '';
  position: absolute;
  top: 20px;
  left: calc(16.67% + 1rem);
  right: calc(16.67% + 1rem);
  height: 3px;
  background: var(--color-primary);
  z-index: 0;
}

.step-card {
  background: var(--color-background-alt);
  padding: 2rem;
  border-radius: 16px;
  text-align: center;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.05);
  position: relative;
  z-index: 1;
  border: 1px solid var(--color-border);
}

.step-badge {
  display: inline-block;
  padding: 0.5rem 1rem;
  background: var(--color-primary);
  color: var(--color-text);
  font-size: 0.75rem;
  font-weight: 700;
  text-transform: uppercase;
  letter-spacing: 0.05em;
  border-radius: 50px;
  margin-bottom: 1.25rem;
}

.step-card-title {
  font-size: 1.25rem;
  margin-bottom: 0.75rem;
  color: var(--color-text);
}

.step-text {
  color: var(--color-muted);
  margin: 0;
  line-height: 1.7;
}

@media (max-width: 1024px) {
  .steps-grid {
    grid-template-columns: 1fr;
    max-width: 500px;
    margin: 0 auto;
  }

  .steps-grid::before {
    display: none;
  }
}
</style>