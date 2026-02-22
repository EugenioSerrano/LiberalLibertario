<script setup lang="ts">
defineProps<{
  quote: string
  note?: string
  author?: string
}>()
</script>

<template>
  <section class="section quote-section">
    <div class="container">
      <div class="quote-container">
        <blockquote class="quote">
          <span class="quote-mark">"</span>
          <p class="quote-text">{{ quote }}</p>
          <span class="quote-mark quote-mark-end">"</span>
        </blockquote>
        <p v-if="note" class="quote-note">{{ note }}</p>
        <cite v-if="author" class="quote-author">— {{ author }}</cite>
      </div>
    </div>
  </section>
</template>

<style scoped>
.quote-section {
  background-image: url('@/assets/images/Libertad.png');
  background-size: cover;
  background-position: center;
  background-attachment: fixed;
  position: relative;
  overflow: hidden;
}

.quote-section::before {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(0, 0, 0, 0.6);
  z-index: 1;
}

.quote-container {
  position: relative;
  z-index: 2;
  text-align: center;
  max-width: 800px;
  margin: 0 auto;
  padding: 2rem 0;
}

.quote {
  margin: 0;
  position: relative;
}

.quote-mark {
  font-family: var(--font-accent);
  font-size: 6rem;
  color: var(--color-primary);
  opacity: 0.5;
  line-height: 0;
  position: absolute;
  top: 1rem;
  left: -1rem;
}

.quote-mark-end {
  left: auto;
  right: -1rem;
  top: auto;
  bottom: -2rem;
}

.quote-text {
  font-family: var(--font-accent);
  font-size: clamp(1.5rem, 3vw, 2.25rem);
  font-weight: 400;
  font-style: italic;
  color: #FFFFFF;
  line-height: 1.5;
  margin: 0;
  padding: 0 2rem;
}

.quote-note {
  margin-top: 2rem;
  font-size: 1.125rem;
  color: #D1D5DB;
}

.quote-author {
  display: block;
  margin-top: 1.5rem;
  font-size: 1rem;
  font-style: normal;
  color: var(--color-primary);
  font-weight: 600;
}

@media (max-width: 768px) {
  .quote-mark {
    font-size: 4rem;
    position: static;
    display: block;
    margin-bottom: -1rem;
  }

  .quote-mark-end {
    margin-top: -1rem;
  }

  .quote-text {
    padding: 0;
  }
}
</style>