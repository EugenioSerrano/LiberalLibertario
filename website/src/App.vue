<script setup lang="ts">
import { RouterView, useRoute } from 'vue-router'
import { computed } from 'vue'
import TheHeader from './components/TheHeader.vue'
import TheFooter from './components/TheFooter.vue'

const route = useRoute()
const isMaintenanceMode = computed(() => route.name === 'maintenance')
</script>

<template>
  <div class="app-container">
    <TheHeader v-if="!isMaintenanceMode" />
    <main>
      <RouterView />
    </main>
    <TheFooter v-if="!isMaintenanceMode" />
  </div>
</template>

<style>
:root {
  /* Paleta de colores - Liberal Libertario */
  --color-primary: #F2B400;
  --color-primary-dark: #D9A200;
  --color-primary-light: #FFD54F;
  --color-text: #1F2937;
  --color-text-light: #374151;
  --color-background: #F8FAFC;
  --color-background-alt: #FFFFFF;
  --color-muted: #6B7280;
  --color-border: #E5E7EB;
  
  /* Typography */
  --font-heading: 'Inter', -apple-system, BlinkMacSystemFont, 'Segoe UI', sans-serif;
  --font-body: 'Inter', -apple-system, BlinkMacSystemFont, 'Segoe UI', sans-serif;
  --font-accent: 'Libre Baskerville', Georgia, serif;
  
  /* Spacing */
  --section-gap: 4rem;
  --container-max: 1200px;
  --container-padding: 1.5rem;
}

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

html {
  scroll-behavior: smooth;
}

body {
  font-family: var(--font-body);
  font-size: 16px;
  line-height: 1.6;
  color: var(--color-text);
  background-color: var(--color-background);
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

.app-container {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

main {
  flex: 1;
}

h1, h2, h3, h4, h5, h6 {
  font-family: var(--font-heading);
  font-weight: 700;
  line-height: 1.2;
  color: var(--color-text);
}

h1 {
  font-size: clamp(2rem, 5vw, 3.5rem);
}

h2 {
  font-size: clamp(1.5rem, 4vw, 2.5rem);
}

h3 {
  font-size: clamp(1.25rem, 3vw, 1.75rem);
}

p {
  margin-bottom: 1rem;
}

a {
  color: var(--color-primary-dark);
  text-decoration: none;
  transition: color 0.2s ease;
}

a:hover {
  color: var(--color-primary);
}

img {
  max-width: 100%;
  height: auto;
}

.container {
  width: 100%;
  max-width: var(--container-max);
  margin: 0 auto;
  padding: 0 var(--container-padding);
}

.section {
  padding: var(--section-gap) 0;
}

.section-alt {
  background-color: var(--color-background-alt);
}

.btn {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  padding: 0.875rem 2rem;
  font-family: var(--font-heading);
  font-size: 1rem;
  font-weight: 600;
  text-decoration: none;
  border-radius: 8px;
  border: none;
  cursor: pointer;
  transition: all 0.2s ease;
}

.btn-primary {
  background-color: var(--color-primary);
  color: var(--color-text);
}

.btn-primary:hover {
  background-color: var(--color-primary-dark);
  color: var(--color-text);
  transform: translateY(-2px);
  box-shadow: 0 4px 12px rgba(242, 180, 0, 0.3);
}

.btn-secondary {
  background-color: transparent;
  color: var(--color-text);
  border: 2px solid var(--color-text);
}

.btn-secondary:hover {
  background-color: var(--color-text);
  color: var(--color-background);
}

.text-center {
  text-align: center;
}

.text-muted {
  color: var(--color-muted);
}

@media (max-width: 768px) {
  :root {
    --section-gap: 3rem;
    --container-padding: 1rem;
  }
}
</style>
