<script setup lang="ts">
import PageHeader from '@/components/PageHeader.vue'
import ContactForm from '@/components/ContactForm.vue'
</script>

<template>
  <div class="contacto">
    <PageHeader
      headline="Hablemos"
      subheadline="Estamos abiertos al diálogo y a la cooperación, siempre con coherencia ética y programática."
    />

    <section class="section contact-info-section">
      <div class="container">
        <div class="contact-grid">
          <div class="contact-info">
            <div class="logo-container">
              <img 
                src="@/assets/LogoCondorOriginal.png" 
                alt="Logo Liberal Libertario"
                class="contact-logo"
              />
            </div>
            <h2>Información de contacto</h2>
            
            <div class="info-item">
              <span class="info-icon">📍</span>
              <div class="info-content">
                <h3>Ubicación</h3>
                <p>Traslasierra · Córdoba · Argentina</p>
              </div>
            </div>

            <div class="info-item">
              <span class="info-icon">🌐</span>
              <div class="info-content">
                <h3>Sitio web</h3>
                <p>liberal-libertario.com</p>
              </div>
            </div>

            <div class="social-section">
              <h3>Seguinos en redes</h3>
              <div class="social-links">
                <a href="https://www.tiktok.com/@LibertariosTras" target="_blank" rel="noopener noreferrer" class="social-link" aria-label="TikTok">
                  <svg viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M19.59 6.69a4.83 4.83 0 0 1-3.77-4.25V2h-3.45v13.67a2.89 2.89 0 0 1-5.2 1.74 2.89 2.89 0 0 1 2.31-4.64 2.93 2.93 0 0 1 .88.13V9.4a6.84 6.84 0 0 0-1-.05A6.33 6.33 0 0 0 5 20.1a6.34 6.34 0 0 0 10.86-4.43v-7a8.16 8.16 0 0 0 4.77 1.52v-3.4a4.85 4.85 0 0 1-1-.1z" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
                  </svg>
                </a>
                <a href="https://www.facebook.com/groups/LibertariosTras" target="_blank" rel="noopener noreferrer" class="social-link" aria-label="Facebook">
                  <svg viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M18 2h-3a5 5 0 0 0-5 5v3H7v4h3v8h4v-8h3l1-4h-4V7a1 1 0 0 1 1-1h3z" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                  </svg>
                </a>
                <a href="https://x.com/LibertariosTras" target="_blank" rel="noopener noreferrer" class="social-link" aria-label="X (Twitter)">
                  <svg viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M4 4l11.5 16h4.5M4 20L20 4" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                  </svg>
                </a>
              </div>
            </div>
          </div>

          <div class="contact-form-wrapper">
            <ContactForm
              title="Envianos un mensaje"
              text="Respondemos a la brevedad."
            />
          </div>
        </div>
      </div>
    </section>

    <section class="section map-section">
      <div class="container">
        <div class="map-content">
          <h2>Nuestra región</h2>
          <p>
            Traslasierra es un valle ubicado al oeste de las Sierras Grandes, en la provincia
            de Córdoba. Un lugar donde la naturaleza, el trabajo y la comunidad se encuentran.
          </p>
          <div class="map-placeholder">
            <img 
              src="@/assets/images/EJS_2247.jpg" 
              alt="Paisaje de Traslasierra"
              class="map-image"
            />
            <div class="map-overlay">
              <span class="location-pin">📍</span>
              <span class="location-text">Traslasierra, Córdoba</span>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<style scoped>
.contact-info-section {
  background: var(--color-background);
}

.contact-grid {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 4rem;
  align-items: start;
}

.logo-container {
  text-align: center;
  margin-bottom: 3rem;
  padding-bottom: 2rem;
  border-bottom: 1px solid var(--color-border);
}

.contact-logo {
  width: 400px;
  height: auto;
  max-width: 100%;
}

.contact-info h2 {
  margin-bottom: 2rem;
}

.info-item {
  display: flex;
  gap: 1rem;
  margin-bottom: 1.5rem;
}

.info-icon {
  font-size: 1.5rem;
  flex-shrink: 0;
}

.info-content h3 {
  font-size: 1rem;
  font-weight: 600;
  margin-bottom: 0.25rem;
  color: var(--color-text);
}

.info-content p {
  margin: 0;
  color: var(--color-muted);
}

.social-section {
  margin-top: 2rem;
  padding-top: 2rem;
  border-top: 1px solid var(--color-border);
}

.social-section h3 {
  font-size: 1rem;
  margin-bottom: 0.5rem;
}

.social-note {
  font-size: 0.875rem;
  color: var(--color-muted);
  margin-bottom: 1rem;
}

.social-links {
  display: flex;
  gap: 1rem;
}

.social-link {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 44px;
  height: 44px;
  background: var(--color-background-alt);
  border: 1px solid var(--color-border);
  border-radius: 8px;
  color: var(--color-muted);
  transition: all 0.2s ease;
}

.social-link:hover {
  background: var(--color-primary);
  border-color: var(--color-primary);
  color: var(--color-text);
}

.social-link svg {
  width: 20px;
  height: 20px;
}

.note-box {
  margin-top: 2rem;
  padding: 1rem;
  background: rgba(242, 180, 0, 0.1);
  border-radius: 8px;
  border-left: 3px solid var(--color-primary);
}

.note-box p {
  margin: 0;
  font-size: 0.875rem;
  color: var(--color-text-light);
}

.contact-form-wrapper :deep(.contact-form-section) {
  padding: 0;
  background: transparent;
}

.contact-form-wrapper :deep(.contact-card) {
  padding: 2rem;
}

.map-section {
  background: var(--color-background-alt);
}

.map-content {
  text-align: center;
}

.map-content h2 {
  margin-bottom: 1rem;
}

.map-content > p {
  max-width: 600px;
  margin: 0 auto 2rem;
  color: var(--color-muted);
}

.map-placeholder {
  position: relative;
  border-radius: 16px;
  overflow: hidden;
  max-height: 400px;
}

.map-image {
  width: 100%;
  height: 400px;
  object-fit: cover;
}

.map-overlay {
  position: absolute;
  bottom: 2rem;
  left: 50%;
  transform: translateX(-50%);
  background: var(--color-background-alt);
  padding: 1rem 2rem;
  border-radius: 50px;
  display: flex;
  align-items: center;
  gap: 0.5rem;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2);
}

.location-pin {
  font-size: 1.25rem;
}

.location-text {
  font-weight: 600;
  color: var(--color-text);
}

@media (max-width: 1024px) {
  .contact-grid {
    grid-template-columns: 1fr;
    gap: 3rem;
  }
}

@media (max-width: 640px) {
  .map-placeholder {
    max-height: 300px;
  }

  .map-image {
    height: 300px;
  }
}
</style>