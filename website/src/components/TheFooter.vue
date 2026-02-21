<script setup lang="ts">
import { RouterLink } from 'vue-router'

const currentYear = new Date().getFullYear()

const quickLinks = [
  { label: 'Principios', path: '/principios' },
  { label: 'Qué hacemos', path: '/que-hacemos' },
  { label: 'Aprendamos juntos', path: '/aprendamos-juntos' },
  { label: 'Sumate', path: '/sumate' },
  { label: 'Contacto', path: '/contacto' }
]
</script>

<template>
  <footer class="footer">
    <div class="container">
      <div class="footer-content">
        <div class="footer-brand">
          <RouterLink to="/" class="footer-logo-link">
            <img 
              src="@/assets/LogoCondorBlanco.png" 
              alt="Libertarios Traslasierra" 
              class="footer-logo"
            />
          </RouterLink>
          <p class="footer-tagline">Una idea de libertad que echó raíces en Traslasierra</p>
          <p class="footer-location">Traslasierra · Córdoba · Argentina</p>
        </div>

        <div class="footer-links">
          <h4 class="footer-heading">Enlaces</h4>
          <ul class="footer-nav">
            <li v-for="link in quickLinks" :key="link.path">
              <RouterLink :to="link.path" class="footer-link">{{ link.label }}</RouterLink>
            </li>
          </ul>
        </div>

        <div class="footer-values">
          <h4 class="footer-heading">Nuestros valores</h4>
          <ul class="values-list">
            <li>Libertad individual</li>
            <li>Estado limitado</li>
            <li>Igualdad ante la ley</li>
            <li>Cultura del trabajo</li>
          </ul>
        </div>

        <div class="footer-cta">
          <h4 class="footer-heading">¿Compartís nuestras ideas?</h4>
          <p>Sumate a la defensa de la libertad en Traslasierra.</p>
          <RouterLink to="/sumate" class="btn btn-primary">Sumate</RouterLink>
        </div>
      </div>

      <div class="footer-bottom">
        <p class="copyright">
          © {{ currentYear }} Libertarios Traslasierra. Todos los derechos reservados.
        </p>
        <p class="footer-quote">
          "Nuestra lealtad es a los principios, no a personas."
        </p>
      </div>
    </div>
  </footer>
</template>

<style scoped>
.footer {
  background-color: var(--color-text);
  color: #E5E7EB;
  padding: 4rem 0 2rem;
  margin-top: auto;
}

.footer-content {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  gap: 3rem;
  margin-bottom: 3rem;
}

.footer-brand {
  grid-column: span 1;
}

.footer-logo-link {
  display: inline-block;
  margin-bottom: 1rem;
}

.footer-logo {
  height: 60px;
  width: auto;
}

.footer-tagline {
  font-family: var(--font-accent);
  font-style: italic;
  font-size: 1rem;
  color: #D1D5DB;
  margin-bottom: 0.5rem;
}

.footer-location {
  font-size: 0.875rem;
  color: var(--color-muted);
}

.footer-heading {
  font-size: 1rem;
  font-weight: 600;
  color: #FFFFFF;
  margin-bottom: 1.25rem;
  text-transform: uppercase;
  letter-spacing: 0.05em;
}

.footer-nav {
  list-style: none;
}

.footer-nav li {
  margin-bottom: 0.75rem;
}

.footer-link {
  color: #D1D5DB;
  text-decoration: none;
  font-size: 0.9375rem;
  transition: color 0.2s ease;
}

.footer-link:hover {
  color: var(--color-primary);
}

.values-list {
  list-style: none;
}

.values-list li {
  font-size: 0.9375rem;
  color: #D1D5DB;
  margin-bottom: 0.5rem;
  padding-left: 1.25rem;
  position: relative;
}

.values-list li::before {
  content: '';
  position: absolute;
  left: 0;
  top: 50%;
  transform: translateY(-50%);
  width: 6px;
  height: 6px;
  background-color: var(--color-primary);
  border-radius: 50%;
}

.footer-cta p {
  font-size: 0.9375rem;
  color: #D1D5DB;
  margin-bottom: 1.25rem;
}

.footer-cta .btn {
  padding: 0.75rem 1.5rem;
  font-size: 0.875rem;
}

.footer-bottom {
  border-top: 1px solid #374151;
  padding-top: 2rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-wrap: wrap;
  gap: 1rem;
}

.copyright {
  font-size: 0.875rem;
  color: var(--color-muted);
  margin: 0;
}

.footer-quote {
  font-family: var(--font-accent);
  font-style: italic;
  font-size: 0.875rem;
  color: #E5E7EB;
  margin: 0;
}

@media (max-width: 1024px) {
  .footer-content {
    grid-template-columns: repeat(2, 1fr);
  }

  .footer-brand {
    grid-column: span 2;
  }
}

@media (max-width: 640px) {
  .footer {
    padding: 3rem 0 1.5rem;
  }

  .footer-content {
    grid-template-columns: 1fr;
    gap: 2rem;
  }

  .footer-brand {
    grid-column: span 1;
    text-align: center;
  }

  .footer-logo-link {
    display: flex;
    justify-content: center;
  }

  .footer-bottom {
    flex-direction: column;
    text-align: center;
  }
}
</style>