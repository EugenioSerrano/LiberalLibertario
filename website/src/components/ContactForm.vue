<script setup lang="ts">
import { ref, reactive } from 'vue'

defineProps<{
  title?: string
  text?: string
}>()

const form = reactive({
  name: '',
  contact: '',
  localidad: '',
  message: ''
})

const isSubmitting = ref(false)
const isSubmitted = ref(false)
const errorMessage = ref('')

// URL de la API - ajustar según el entorno
const API_URL = import.meta.env.VITE_API_URL || 'http://localhost:5000'
const API_KEY = import.meta.env.VITE_API_KEY

const handleSubmit = async () => {
  if (!form.name || !form.contact || !form.localidad || !form.message) {
    errorMessage.value = 'Por favor, completá todos los campos.'
    return
  }

  isSubmitting.value = true
  errorMessage.value = ''

  try {
    const response = await fetch(`${API_URL}/api/contact`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'X-API-Key': API_KEY
      },
      body: JSON.stringify({
        name: form.name,
        contact: form.contact,
        localidad: form.localidad,
        message: form.message
      })
    })

    if (!response.ok) {
      // Intentar parsear el error como JSON, si falla usar mensaje genérico
      let errorMsg = 'Error al enviar el mensaje'
      try {
        const errorData = await response.json()
        errorMsg = errorData.error || errorData.message || errorMsg
      } catch {
        // Si no hay JSON válido, usar el status text
        errorMsg = `Error del servidor (${response.status}): ${response.statusText}`
      }
      throw new Error(errorMsg)
    }

    // Parsear respuesta exitosa
    await response.json()
    
    isSubmitted.value = true
    form.name = ''
    form.contact = ''
    form.localidad = ''
    form.message = ''
  } catch (error) {
    console.error('Error sending contact form:', error)
    errorMessage.value = error instanceof Error 
      ? error.message 
      : 'Hubo un error al enviar el mensaje. Intentá nuevamente.'
  } finally {
    isSubmitting.value = false
  }
}
</script>

<template>
  <section class="section contact-form-section">
    <div class="container">
      <div class="contact-card">
        <h2 v-if="title" class="contact-title">{{ title }}</h2>
        <p v-if="text" class="contact-text">{{ text }}</p>

        <div v-if="isSubmitted" class="success-message">
          <span class="success-icon">✓</span>
          <h3>¡Mensaje enviado!</h3>
          <p>Gracias por escribir. Te respondo a la brevedad.</p>
          <button class="btn btn-secondary" @click="isSubmitted = false">
            Enviar otro mensaje
          </button>
        </div>

        <form v-else class="form" @submit.prevent="handleSubmit">
          <div class="form-group">
            <label for="name" class="form-label">Nombre *</label>
            <input
              id="name"
              v-model="form.name"
              type="text"
              class="form-input"
              placeholder="Tu nombre"
              required
            />
          </div>

          <div class="form-group">
            <label for="contact" class="form-label">WhatsApp o Email *</label>
            <input
              id="contact"
              v-model="form.contact"
              type="text"
              class="form-input"
              placeholder="Tu WhatsApp o email"
              required
            />
          </div>

          <div class="form-group">
            <label for="localidad" class="form-label">Localidad *</label>
            <input
              id="localidad"
              v-model="form.localidad"
              type="text"
              class="form-input"
              placeholder="Tu localidad"
              required
            />
          </div>

          <div class="form-group">
            <label for="message" class="form-label">Mensaje *</label>
            <textarea
              id="message"
              v-model="form.message"
              class="form-textarea"
              placeholder="¿En qué podemos ayudarte?"
              rows="5"
              required
            ></textarea>
          </div>

          <p v-if="errorMessage" class="error-message">{{ errorMessage }}</p>

          <button 
            type="submit" 
            class="btn btn-primary btn-submit"
            :disabled="isSubmitting"
          >
            {{ isSubmitting ? 'Enviando...' : 'Enviar mensaje' }}
          </button>
        </form>
      </div>
    </div>
  </section>
</template>

<style scoped>
.contact-form-section {
  background: var(--color-background-alt);
}

.contact-card {
  max-width: 600px;
  margin: 0 auto;
  background: var(--color-background);
  padding: 3rem;
  border-radius: 20px;
  box-shadow: 0 8px 40px rgba(0, 0, 0, 0.08);
  border: 1px solid var(--color-border);
}

.contact-title {
  text-align: center;
  margin-bottom: 0.75rem;
}

.contact-text {
  text-align: center;
  color: var(--color-muted);
  margin-bottom: 2rem;
}

.form {
  display: flex;
  flex-direction: column;
  gap: 1.5rem;
}

.form-group {
  display: flex;
  flex-direction: column;
}

.form-label {
  font-size: 0.875rem;
  font-weight: 600;
  color: var(--color-text);
  margin-bottom: 0.5rem;
}

.form-input,
.form-textarea {
  padding: 0.875rem 1rem;
  font-family: var(--font-body);
  font-size: 1rem;
  color: var(--color-text);
  background: var(--color-background-alt);
  border: 2px solid var(--color-border);
  border-radius: 8px;
  transition: border-color 0.2s ease, box-shadow 0.2s ease;
}

.form-input:focus,
.form-textarea:focus {
  outline: none;
  border-color: var(--color-primary);
  box-shadow: 0 0 0 3px rgba(242, 180, 0, 0.15);
}

.form-input::placeholder,
.form-textarea::placeholder {
  color: var(--color-muted);
}

.form-textarea {
  resize: vertical;
  min-height: 120px;
}

.btn-submit {
  width: 100%;
  margin-top: 0.5rem;
}

.btn-submit:disabled {
  opacity: 0.7;
  cursor: not-allowed;
}

.error-message {
  color: #DC2626;
  font-size: 0.875rem;
  text-align: center;
  margin: 0;
}

.success-message {
  text-align: center;
  padding: 2rem 0;
}

.success-icon {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 64px;
  height: 64px;
  background: var(--color-primary);
  color: var(--color-text);
  font-size: 2rem;
  font-weight: 700;
  border-radius: 50%;
  margin-bottom: 1.5rem;
}

.success-message h3 {
  font-size: 1.5rem;
  margin-bottom: 0.5rem;
}

.success-message p {
  color: var(--color-muted);
  margin-bottom: 1.5rem;
}

@media (max-width: 640px) {
  .contact-card {
    padding: 2rem;
  }
}
</style>