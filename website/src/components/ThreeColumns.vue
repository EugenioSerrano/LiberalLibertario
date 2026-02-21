<script setup lang="ts">
interface Column {
  title: string
  bullets: string[]
}

defineProps<{
  columns: Column[]
}>()
</script>

<template>
  <section class="section columns-section">
    <div class="container">
      <div class="columns-grid">
        <article v-for="(column, index) in columns" :key="index" class="column-card">
          <div class="column-number">{{ index + 1 }}</div>
          <h3 class="column-title">{{ column.title }}</h3>
          <ul class="column-bullets">
            <li v-for="(bullet, bulletIndex) in column.bullets" :key="bulletIndex">
              {{ bullet }}
            </li>
          </ul>
        </article>
      </div>
    </div>
  </section>
</template>

<style scoped>
.columns-section {
  background: var(--color-background);
}

.columns-grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 2rem;
}

.column-card {
  background: var(--color-background-alt);
  padding: 2rem;
  border-radius: 16px;
  border-top: 4px solid var(--color-primary);
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.05);
  position: relative;
}

.column-number {
  position: absolute;
  top: -20px;
  left: 2rem;
  width: 40px;
  height: 40px;
  background: var(--color-primary);
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  font-family: var(--font-heading);
  font-size: 1.25rem;
  font-weight: 700;
  color: var(--color-text);
  box-shadow: 0 4px 12px rgba(242, 180, 0, 0.3);
}

.column-title {
  font-size: 1.25rem;
  margin-top: 0.5rem;
  margin-bottom: 1.25rem;
  color: var(--color-text);
}

.column-bullets {
  list-style: none;
  margin: 0;
  padding: 0;
}

.column-bullets li {
  position: relative;
  padding-left: 1.5rem;
  margin-bottom: 0.75rem;
  color: var(--color-text-light);
  line-height: 1.7;
  font-size: 0.9375rem;
}

.column-bullets li:last-child {
  margin-bottom: 0;
}

.column-bullets li::before {
  content: '→';
  position: absolute;
  left: 0;
  color: var(--color-primary);
  font-weight: 600;
}

@media (max-width: 1024px) {
  .columns-grid {
    grid-template-columns: 1fr;
    max-width: 600px;
    margin: 0 auto;
  }
}

@media (max-width: 768px) {
  .column-card {
    padding: 1.5rem;
  }
}
</style>