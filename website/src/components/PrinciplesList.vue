<script setup lang="ts">
interface Principle {
  key: string
  title: string
  icon?: string
  bullets: string[]
}

defineProps<{
  intro?: string
  items: Principle[]
}>()
</script>

<template>
  <section class="section principles-section">
    <div class="container">
      <p v-if="intro" class="principles-intro">{{ intro }}</p>
      <div class="principles-list">
        <article v-for="item in items" :key="item.key" class="principle-card">
          <div class="principle-header">
            <div class="principle-icon">
              <font-awesome-icon v-if="item.icon" :icon="item.icon" />
            </div>
            <h3 class="principle-title">{{ item.title }}</h3>
          </div>
          <ul class="principle-bullets">
            <li v-for="(bullet, index) in item.bullets" :key="index">
              {{ bullet }}
            </li>
          </ul>
        </article>
      </div>
    </div>
  </section>
</template>

<style scoped>
.principles-section {
  background: var(--color-background);
}

.principles-intro {
  text-align: center;
  font-size: 1.25rem;
  color: var(--color-text-light);
  max-width: 800px;
  margin: 0 auto 3rem;
  line-height: 1.7;
}

.principles-list {
  display: grid;
  gap: 2rem;
}

.principle-card {
  background: var(--color-background-alt);
  padding: 2rem;
  border-radius: 16px;
  border-left: 4px solid var(--color-primary);
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.05);
}

.principle-header {
  display: flex;
  align-items: center;
  gap: 1rem;
  margin-bottom: 1.25rem;
}

.principle-icon {
  font-size: 2rem;
}

.principle-title {
  font-size: 1.375rem;
  margin: 0;
  color: var(--color-text);
}

.principle-bullets {
  list-style: none;
  margin: 0;
  padding: 0;
}

.principle-bullets li {
  position: relative;
  padding-left: 1.75rem;
  margin-bottom: 0.75rem;
  color: var(--color-text-light);
  line-height: 1.7;
}

.principle-bullets li:last-child {
  margin-bottom: 0;
}

.principle-bullets li::before {
  content: '';
  position: absolute;
  left: 0;
  top: 0.7em;
  width: 8px;
  height: 8px;
  background: var(--color-primary);
  border-radius: 50%;
}

@media (max-width: 768px) {
  .principle-card {
    padding: 1.5rem;
  }
}
</style>