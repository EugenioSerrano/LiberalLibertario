<script setup lang="ts">
defineProps<{
  headline: string
  subheadline?: string
}>()
</script>

<template>
  <section class="page-header">
    <div class="container">
      <h1 class="page-headline">{{ headline }}</h1>
      <p v-if="subheadline" class="page-subheadline">{{ subheadline }}</p>
    </div>
  </section>
</template>

<style scoped>
.page-header {
  background: linear-gradient(135deg, var(--color-text) 0%, #374151 100%);
  padding: 5rem 0 4rem;
  text-align: center;
  position: relative;
}

.page-header::after {
  content: '';
  position: absolute;
  bottom: -1px;
  left: 0;
  right: 0;
  height: 60px;
  background: var(--color-background);
  clip-path: polygon(0 100%, 100% 100%, 100% 0, 0 100%);
}

.page-headline {
  color: #FFFFFF;
  font-size: clamp(2rem, 5vw, 3rem);
  margin-bottom: 1rem;
}

.page-subheadline {
  color: #D1D5DB;
  font-size: 1.25rem;
  max-width: 700px;
  margin: 0 auto;
  line-height: 1.7;
}

@media (max-width: 768px) {
  .page-header {
    padding: 4rem 0 3rem;
  }
}
</style>