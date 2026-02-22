<script setup lang="ts">
import PageHeader from '@/components/PageHeader.vue'
import ContactForm from '@/components/ContactForm.vue'
</script>

<template>
  <div class="contacto">
    <PageHeader
      headline="Hablemos"
      subheadline="¿Querés conversar sobre ideas de libertad? Mandame un mensaje."
    />

    <section class="section contact-info-section">
      <div class="container">
        <div class="contact-grid">
          <div class="contact-info">
            <div class="logo-container">
              <img 
                src="@/assets/LogoLiberalLibertario.png" 
                alt="Logo Liberal Libertario"
                class="contact-logo"
              />
            </div>
            <p class="contact-intro">
              Si querés conversar sobre ideas de libertad, filosofía política, o simplemente compartir tu opinión, estoy abierto al diálogo.
            </p>
          </div>

          <div class="contact-form-wrapper">
            <ContactForm
              title="Enviame un mensaje"
              text="Te respondo a la brevedad."
            />
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

.contact-intro {
  font-size: 1.125rem;
  line-height: 1.8;
  color: var(--color-muted);
  text-align: center;
  max-width: 500px;
  margin: 0 auto;
}

.contact-form-wrapper :deep(.contact-form-section) {
  padding: 0;
  background: transparent;
}

.contact-form-wrapper :deep(.contact-card) {
  padding: 2rem;
}

@media (max-width: 1024px) {
  .contact-grid {
    grid-template-columns: 1fr;
    gap: 3rem;
  }
}
</style>