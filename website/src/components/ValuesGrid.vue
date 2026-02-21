<script setup lang="ts">
interface ValueItem {
  title: string
  description: string
}

defineProps<{
  title?: string
  items: ValueItem[]
}>()
</script>

<template>
  <section class="section values-section">
    <div class="container">
      <h2 v-if="title" class="values-title">{{ title }}</h2>
      <div class="values-grid">
        <article v-for="(item, index) in items" :key="index" class="value-card">
          <div class="value-icon">
            <svg viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
              <path d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
            </svg>
          </div>
          <h3 class="value-title">{{ item.title }}</h3>
          <p class="value-description">{{ item.description }}</p>
        </article>
      </div>
    </div>
  </section>
</template>

<style scoped>
.values-section {
  background: var(--color-background-alt);
}

.values-title {
  text-align: center;
  margin-bottom: 3rem;
}

.values-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(280px, 1fr));
  gap: 2rem;
}

.value-card {
  background: var(--color-background);
  padding: 2rem;
  border-radius: 12px;
  text-align: center;
  border: 1px solid var(--color-border);
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.value-card:hover {
  transform: translateY(-4px);
  box-shadow: 0 8px 30px rgba(0, 0, 0, 0.08);
}

.value-icon {
  width: 56px;
  height: 56px;
  margin: 0 auto 1.25rem;
  color: var(--color-primary);
}

.value-icon svg {
  width: 100%;
  height: 100%;
}

.value-title {
  font-size: 1.25rem;
  margin-bottom: 0.75rem;
  color: var(--color-text);
}

.value-description {
  color: var(--color-muted);
  margin: 0;
  line-height: 1.7;
}
</style>