<script setup lang="ts">
import { ref } from 'vue'

// Import all images from Traslasierra
import img1 from '@/assets/images/DSC_1532.jpg'
import img2 from '@/assets/images/DSC_6880.jpg'
import img3 from '@/assets/images/DSC_6943.jpg'
import img4 from '@/assets/images/EJS_0988.jpg'
import img5 from '@/assets/images/EJS_2247.jpg'
import img6 from '@/assets/images/EJS_8955.jpg'
import img7 from '@/assets/images/EJS_9371.jpg'
import img8 from '@/assets/images/_DSC2704.jpg'
import img9 from '@/assets/images/_DSC2713.jpg'
import img10 from '@/assets/images/_EJS2329.jpg'

const images = [
  { src: img1, alt: 'Paisaje de Traslasierra' },
  { src: img2, alt: 'Vista de las sierras' },
  { src: img3, alt: 'Naturaleza de Traslasierra' },
  { src: img4, alt: 'Paisaje serrano' },
  { src: img5, alt: 'Atardecer en Traslasierra' },
  { src: img6, alt: 'Montañas de Córdoba' },
  { src: img7, alt: 'Valle de Traslasierra' },
  { src: img8, alt: 'Sierras cordobesas' },
  { src: img9, alt: 'Cielo de Traslasierra' },
  { src: img10, alt: 'Paisaje natural' }
]

const selectedImage = ref<string | null>(null)

const openLightbox = (src: string) => {
  selectedImage.value = src
}

const closeLightbox = () => {
  selectedImage.value = null
}
</script>

<template>
  <section class="section gallery-section">
    <div class="container">
      <h2 class="gallery-title">Nuestra tierra: Traslasierra</h2>
      <p class="gallery-subtitle">
        Un valle cordobés donde echamos raíces para defender la libertad
      </p>
      <div class="gallery-grid">
        <div 
          v-for="(image, index) in images" 
          :key="index" 
          class="gallery-item"
          :class="{ 'gallery-item-large': index === 0 || index === 5 }"
          @click="openLightbox(image.src)"
        >
          <img :src="image.src" :alt="image.alt" loading="lazy" />
          <div class="gallery-overlay">
            <span class="gallery-zoom">🔍</span>
          </div>
        </div>
      </div>
    </div>

    <!-- Lightbox -->
    <Teleport to="body">
      <div v-if="selectedImage" class="lightbox" @click="closeLightbox">
        <button class="lightbox-close" @click="closeLightbox">&times;</button>
        <img :src="selectedImage" alt="Imagen ampliada" class="lightbox-image" />
      </div>
    </Teleport>
  </section>
</template>

<style scoped>
.gallery-section {
  background: var(--color-background);
}

.gallery-title {
  text-align: center;
  margin-bottom: 0.75rem;
}

.gallery-subtitle {
  text-align: center;
  color: var(--color-muted);
  font-size: 1.125rem;
  margin-bottom: 3rem;
  max-width: 600px;
  margin-left: auto;
  margin-right: auto;
}

.gallery-grid {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  grid-auto-rows: 200px;
  gap: 1rem;
}

.gallery-item {
  position: relative;
  border-radius: 12px;
  overflow: hidden;
  cursor: pointer;
}

.gallery-item-large {
  grid-column: span 2;
  grid-row: span 2;
}

.gallery-item img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  transition: transform 0.5s ease;
}

.gallery-item:hover img {
  transform: scale(1.1);
}

.gallery-overlay {
  position: absolute;
  inset: 0;
  background: rgba(31, 41, 55, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
  opacity: 0;
  transition: opacity 0.3s ease;
}

.gallery-item:hover .gallery-overlay {
  opacity: 1;
}

.gallery-zoom {
  font-size: 2rem;
  color: #FFFFFF;
}

.lightbox {
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.95);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 9999;
  padding: 2rem;
}

.lightbox-close {
  position: absolute;
  top: 1.5rem;
  right: 1.5rem;
  background: none;
  border: none;
  color: #FFFFFF;
  font-size: 3rem;
  cursor: pointer;
  line-height: 1;
  transition: color 0.2s ease;
}

.lightbox-close:hover {
  color: var(--color-primary);
}

.lightbox-image {
  max-width: 90%;
  max-height: 90vh;
  object-fit: contain;
  border-radius: 8px;
}

@media (max-width: 1024px) {
  .gallery-grid {
    grid-template-columns: repeat(3, 1fr);
    grid-auto-rows: 180px;
  }
}

@media (max-width: 768px) {
  .gallery-grid {
    grid-template-columns: repeat(2, 1fr);
    grid-auto-rows: 150px;
  }

  .gallery-item-large {
    grid-column: span 2;
    grid-row: span 1;
  }
}

@media (max-width: 480px) {
  .gallery-grid {
    grid-template-columns: 1fr;
    grid-auto-rows: 200px;
  }

  .gallery-item-large {
    grid-column: span 1;
  }
}
</style>