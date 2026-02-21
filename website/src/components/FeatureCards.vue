<script setup lang="ts">
interface FeatureItem {
  title: string
  description: string
  icon?: string
}

defineProps<{
  title?: string
  items: FeatureItem[]
}>()
</script>

<template>
  <section class="section features">
    <div class="container">
      <h2 v-if="title" class="features-title">{{ title }}</h2>
      <div class="features-grid">
        <article v-for="(item, index) in items" :key="index" class="feature-card">
          <span v-if="item.icon" class="feature-icon">{{ item.icon }}</span>
          <h3 class="feature-title">{{ item.title }}</h3>
          <p class="feature-description">{{ item.description }}</p>
        </article>
      </div>
    </div>
  </section>
</template>

<style scoped>
.features {
  background-color: var(--color-background);
}

.features-title {
  text-align: center;
  margin-bottom: 3rem;
}

.features-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(280px, 1fr));
  gap: 2rem;
}

.feature-card {
  background: var(--color-background-alt);
  padding: 2.5rem;
  border-radius: 16px;
  text-align: center;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.05);
  transition: transform 0.3s ease, box-shadow 0.3s ease;
  border: 1px solid var(--color-border);
}

.feature-card:hover {
  transform: translateY(-8px);
  box-shadow: 0 12px 40px rgba(0, 0, 0, 0.1);
}

.feature-icon {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 72px;
  height: 72px;
  font-size: 2rem;
  background: linear-gradient(135deg, var(--color-primary) 0%, var(--color-primary-dark) 100%);
  border-radius: 50%;
  margin-bottom: 1.5rem;
  box-shadow: 0 4px 16px rgba(242, 180, 0, 0.3);
}

.feature-title {
  font-size: 1.5rem;
  margin-bottom: 1rem;
  color: var(--color-text);
}

.feature-description {
  color: var(--color-muted);
  line-height: 1.7;
  margin: 0;
}

@media (max-width: 768px) {
  .feature-card {
    padding: 2rem;
  }
}
</style>