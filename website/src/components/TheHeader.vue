<script setup lang="ts">
import { ref } from 'vue'
import { RouterLink } from 'vue-router'

const isMenuOpen = ref(false)

const navItems = [
  { label: 'Home', path: '/' },
  { label: 'Quiénes somos', path: '/quienes-somos' },
  { label: 'Origen', path: '/origen' },
  { label: 'Principios', path: '/principios' },
  { label: 'Qué hacemos', path: '/que-hacemos' },
  { label: 'Cómo trabajamos', path: '/como-trabajamos' },
  { label: 'Aprendamos juntos', path: '/aprendamos-juntos' },
  { label: 'Sumate', path: '/sumate' },
  { label: 'Contacto', path: '/contacto' }
]

const toggleMenu = () => {
  isMenuOpen.value = !isMenuOpen.value
}

const closeMenu = () => {
  isMenuOpen.value = false
}
</script>

<template>
  <header class="header">
    <div class="container header-container">
      <RouterLink to="/" class="logo-link" @click="closeMenu">
        <img 
          src="@/assets/LogoCondorOriginal.png" 
          alt="Libertarios Traslasierra" 
          class="logo"
        />
        <span class="logo-text">Libertarios Traslasierra</span>
      </RouterLink>

      <button 
        class="menu-toggle" 
        @click="toggleMenu" 
        :aria-expanded="isMenuOpen"
        aria-label="Toggle menu"
      >
        <span class="hamburger" :class="{ active: isMenuOpen }">
          <span></span>
          <span></span>
          <span></span>
        </span>
      </button>

      <nav class="nav" :class="{ open: isMenuOpen }">
        <ul class="nav-list">
          <li v-for="item in navItems" :key="item.path" class="nav-item">
            <RouterLink 
              :to="item.path" 
              class="nav-link"
              @click="closeMenu"
            >
              {{ item.label }}
            </RouterLink>
          </li>
        </ul>
      </nav>
    </div>
  </header>
</template>

<style scoped>
.header {
  position: sticky;
  top: 0;
  z-index: 1000;
  background-color: var(--color-background-alt);
  border-bottom: 1px solid var(--color-border);
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.05);
}

.header-container {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding-top: 1rem;
  padding-bottom: 1rem;
}

.logo-link {
  display: flex;
  align-items: center;
  gap: 0.75rem;
  text-decoration: none;
}

.logo {
  height: 50px;
  width: auto;
}

.logo-text {
  font-family: var(--font-heading);
  font-size: 1.25rem;
  font-weight: 700;
  color: var(--color-text);
}

.menu-toggle {
  display: none;
  background: none;
  border: none;
  cursor: pointer;
  padding: 0.5rem;
  z-index: 1001;
}

.hamburger {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  width: 28px;
  height: 20px;
}

.hamburger span {
  display: block;
  width: 100%;
  height: 3px;
  background-color: var(--color-text);
  border-radius: 2px;
  transition: all 0.3s ease;
}

.hamburger.active span:nth-child(1) {
  transform: rotate(45deg) translate(6px, 6px);
}

.hamburger.active span:nth-child(2) {
  opacity: 0;
}

.hamburger.active span:nth-child(3) {
  transform: rotate(-45deg) translate(6px, -6px);
}

.nav-list {
  display: flex;
  align-items: center;
  gap: 0.25rem;
  list-style: none;
}

.nav-link {
  display: block;
  padding: 0.5rem 0.875rem;
  font-size: 0.9375rem;
  font-weight: 500;
  color: var(--color-text-light);
  text-decoration: none;
  border-radius: 6px;
  transition: all 0.2s ease;
}

.nav-link:hover {
  color: var(--color-text);
  background-color: var(--color-background);
}

.nav-link.router-link-active,
.nav-link.router-link-exact-active {
  color: var(--color-primary-dark);
  background-color: rgba(242, 180, 0, 0.1);
}

@media (max-width: 1024px) {
  .logo-text {
    display: none;
  }

  .menu-toggle {
    display: block;
  }

  .nav {
    position: fixed;
    top: 0;
    right: -100%;
    width: 100%;
    max-width: 320px;
    height: 100vh;
    background-color: var(--color-background-alt);
    box-shadow: -4px 0 20px rgba(0, 0, 0, 0.1);
    transition: right 0.3s ease;
    padding-top: 80px;
    overflow-y: auto;
  }

  .nav.open {
    right: 0;
  }

  .nav-list {
    flex-direction: column;
    align-items: stretch;
    padding: 1rem;
    gap: 0.5rem;
  }

  .nav-link {
    padding: 1rem 1.25rem;
    font-size: 1.0625rem;
  }
}

@media (max-width: 480px) {
  .logo {
    height: 40px;
  }
}
</style>