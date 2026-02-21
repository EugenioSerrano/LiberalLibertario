<script setup lang="ts">
defineProps<{
  eyebrow?: string
  headline: string
  subheadline?: string
  backgroundImage?: string
}>()
</script>

<template>
  <section class="hero" :style="backgroundImage ? { backgroundImage: `url(${backgroundImage})` } : {}">
    <div class="hero-overlay"></div>
    <div class="container hero-content">
      <span v-if="eyebrow" class="hero-eyebrow">{{ eyebrow }}</span>
      <h1 class="hero-headline">{{ headline }}</h1>
      <p v-if="subheadline" class="hero-subheadline">{{ subheadline }}</p>
      <div class="hero-cta">
        <slot name="cta"></slot>
      </div>
    </div>
    <div class="hero-decoration">
      <svg viewBox="0 0 1440 120" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path d="M0 120L60 105C120 90 240 60 360 45C480 30 600 30 720 37.5C840 45 960 60 1080 67.5C1200 75 1320 75 1380 75L1440 75V120H1380C1320 120 1200 120 1080 120C960 120 840 120 720 120C600 120 480 120 360 120C240 120 120 120 60 120H0Z" fill="var(--color-background)"/>
      </svg>
    </div>
  </section>
</template>

<style scoped>
.hero {
  position: relative;
  min-height: 85vh;
  display: flex;
  align-items: center;
  background-image: url('@/assets/images/EJS_2247.jpg');
  background-size: cover;
  background-position: center;
  overflow: hidden;
}

.hero-overlay {
  position: absolute;
  inset: 0;
  background: rgba(0, 0, 0, 0.6);
}

.hero-content {
  position: relative;
  z-index: 1;
  text-align: center;
  padding: 6rem 0;
  max-width: 900px;
  margin: 0 auto;
}

.hero-eyebrow {
  display: inline-block;
  font-size: 0.875rem;
  font-weight: 600;
  text-transform: uppercase;
  letter-spacing: 0.15em;
  color: var(--color-primary);
  margin-bottom: 1.5rem;
  padding: 0.5rem 1rem;
  border: 1px solid var(--color-primary);
  border-radius: 50px;
}

.hero-headline {
  font-size: clamp(2.5rem, 6vw, 4rem);
  font-weight: 800;
  color: #FFFFFF;
  line-height: 1.1;
  margin-bottom: 1.5rem;
}

.hero-subheadline {
  font-size: clamp(1.125rem, 2vw, 1.375rem);
  color: #D1D5DB;
  line-height: 1.7;
  max-width: 700px;
  margin: 0 auto 2.5rem;
}

.hero-cta {
  display: flex;
  gap: 1rem;
  justify-content: center;
  flex-wrap: wrap;
}

.hero-cta :deep(.btn) {
  min-width: 200px;
}

.hero-cta :deep(.btn-secondary) {
  color: #FFFFFF;
  border-color: #FFFFFF;
}

.hero-cta :deep(.btn-secondary:hover) {
  background-color: #FFFFFF;
  color: var(--color-text);
}

.hero-decoration {
  position: absolute;
  bottom: -1px;
  left: 0;
  right: 0;
  width: 100%;
  line-height: 0;
}

.hero-decoration svg {
  width: 100%;
  height: auto;
}

@media (max-width: 768px) {
  .hero {
    min-height: 70vh;
  }

  .hero-content {
    padding: 4rem 1.5rem;
  }

  .hero-eyebrow {
    margin-bottom: 1rem;
  }

  .hero-headline {
    margin-bottom: 1.25rem;
  }

  .hero-subheadline {
    margin-bottom: 2rem;
  }

  .hero-cta :deep(.btn) {
    width: 100%;
    min-width: auto;
  }
}
</style>