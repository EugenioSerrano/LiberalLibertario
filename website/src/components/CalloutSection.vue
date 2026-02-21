<script setup lang="ts">
import { RouterLink } from 'vue-router'

defineProps<{
  title: string
  text: string
  ctaLabel?: string
  ctaHref?: string
}>()
</script>

<template>
  <section class="section callout">
    <div class="container">
      <div class="callout-content">
        <h2 class="callout-title">{{ title }}</h2>
        <p class="callout-text">{{ text }}</p>
        <RouterLink v-if="ctaLabel && ctaHref" :to="ctaHref" class="btn btn-primary">
          {{ ctaLabel }}
        </RouterLink>
      </div>
    </div>
  </section>
</template>

<style scoped>
.callout {
  background: var(--color-background-alt);
}

.callout-content {
  text-align: center;
  max-width: 700px;
  margin: 0 auto;
  padding: 2rem;
  background: linear-gradient(135deg, rgba(242, 180, 0, 0.05) 0%, rgba(242, 180, 0, 0.1) 100%);
  border-radius: 20px;
  border: 2px solid rgba(242, 180, 0, 0.2);
}

.callout-title {
  margin-bottom: 1rem;
  color: var(--color-text);
}

.callout-text {
  font-size: 1.125rem;
  color: var(--color-text-light);
  margin-bottom: 2rem;
  line-height: 1.7;
}

@media (max-width: 768px) {
  .callout-content {
    padding: 1.5rem;
  }
}
</style>