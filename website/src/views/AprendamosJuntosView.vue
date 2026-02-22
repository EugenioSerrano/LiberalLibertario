<script setup lang="ts">
import { ref, onMounted, onUnmounted, nextTick } from 'vue'
import { useRoute } from 'vue-router'
import PageHeader from '@/components/PageHeader.vue'

interface Libro {
  id: string
  titulo: string
  audio: string
  pdf: string
}

interface AudioResumen {
  titulo: string
  audio: string
}

interface Autor {
  id: string
  nombre: string
  iniciales: string
  imagen: string
  descripcion: string
  audioResumen?: AudioResumen
  libros: Libro[]
}

interface Biblioteca {
  introduccion: {
    titulo: string
    subtitulo: string
    descripcion: string
  }
  autores: Autor[]
}

const route = useRoute()
const biblioteca = ref<Biblioteca | null>(null)
const expandedAutores = ref<Set<string>>(new Set())
const currentlyPlaying = ref<string | null>(null)
const audioElement = ref<HTMLAudioElement | null>(null)
const audioProgress = ref<number>(0)
const audioDuration = ref<number>(0)
const isPlaying = ref<boolean>(false)
const copiedLink = ref<string | null>(null)

onMounted(async () => {
  try {
    const response = await fetch('/data/biblioteca.json')
    biblioteca.value = await response.json()
    
    // Check for shared link parameters
    await nextTick()
    const autorId = route.query.autor as string
    const libroId = route.query.libro as string
    
    if (autorId && biblioteca.value) {
      // Expand the author accordion
      expandedAutores.value.add(autorId)
      
      // If libro is specified, prepare the player without autoplay
      if (libroId) {
        const autor = biblioteca.value.autores.find(a => a.id === autorId)
        
        // Check if it's a resumen
        if (libroId === 'resumen' && autor?.audioResumen) {
          setTimeout(() => {
            // Prepare player for resumen without playing
            prepareAudio(`resumen-${autorId}`, autor.audioResumen!.audio)
            // Scroll to the resumen card
            const element = document.getElementById(`resumen-${autorId}`)
            element?.scrollIntoView({ behavior: 'smooth', block: 'center' })
          }, 500)
        } else {
          // Regular libro
          const libro = autor?.libros.find(l => l.id === libroId)
          if (libro) {
            setTimeout(() => {
              // Prepare player without playing
              prepareAudio(libro.id, libro.audio)
              // Scroll to the book
              const element = document.getElementById(`libro-${libroId}`)
              element?.scrollIntoView({ behavior: 'smooth', block: 'center' })
            }, 500)
          }
        }
      }
    }
  } catch (error) {
    console.error('Error loading biblioteca:', error)
  }
})

// Cleanup audio when component is unmounted (e.g., navigating to another page)
onUnmounted(() => {
  if (audioElement.value) {
    audioElement.value.pause()
    audioElement.value.currentTime = 0
    audioElement.value = null
  }
})

const toggleAutor = (autorId: string) => {
  if (expandedAutores.value.has(autorId)) {
    expandedAutores.value.delete(autorId)
  } else {
    expandedAutores.value.add(autorId)
  }
}

const isAutorExpanded = (autorId: string) => {
  return expandedAutores.value.has(autorId)
}

const shareLink = async (autorId: string, libroId: string, libroTitulo: string) => {
  const url = `${window.location.origin}/aprendamos-juntos?autor=${autorId}&libro=${libroId}`
  
  // Use a unique identifier for copiedLink
  const linkId = libroId === 'resumen' ? `resumen-${autorId}` : libroId
  
  try {
    await navigator.clipboard.writeText(url)
    copiedLink.value = linkId
    setTimeout(() => {
      copiedLink.value = null
    }, 2000)
  } catch (err) {
    // Fallback for older browsers
    const textArea = document.createElement('textarea')
    textArea.value = url
    document.body.appendChild(textArea)
    textArea.select()
    document.execCommand('copy')
    document.body.removeChild(textArea)
    copiedLink.value = linkId
    setTimeout(() => {
      copiedLink.value = null
    }, 2000)
  }
}

const playAudio = (libroId: string, audioUrl: string) => {
  if (currentlyPlaying.value === libroId && audioElement.value) {
    // Toggle play/pause
    if (isPlaying.value) {
      audioElement.value.pause()
      isPlaying.value = false
    } else {
      isPlaying.value = true
      audioElement.value.play()
        .catch(() => { isPlaying.value = false })
    }
    return
  }

  // Stop current audio if playing different track
  if (audioElement.value) {
    audioElement.value.pause()
    audioElement.value.currentTime = 0
  }

  // Create new audio
  audioElement.value = new Audio(audioUrl)
  currentlyPlaying.value = libroId
  audioProgress.value = 0
  audioDuration.value = 0

  audioElement.value.addEventListener('loadedmetadata', () => {
    if (audioElement.value) {
      audioDuration.value = audioElement.value.duration
    }
  })

  audioElement.value.addEventListener('play', () => {
    isPlaying.value = true
  })

  audioElement.value.addEventListener('pause', () => {
    isPlaying.value = false
  })

  audioElement.value.addEventListener('timeupdate', () => {
    if (audioElement.value) {
      audioProgress.value = audioElement.value.currentTime
    }
  })

  audioElement.value.addEventListener('ended', () => {
    isPlaying.value = false
    audioProgress.value = 0
  })

  isPlaying.value = true
  audioElement.value.play()
    .catch(() => { isPlaying.value = false })
}

// Prepare audio player without autoplay (for shared links)
const prepareAudio = (libroId: string, audioUrl: string) => {
  // Stop current audio if any
  if (audioElement.value) {
    audioElement.value.pause()
    audioElement.value.currentTime = 0
  }

  // Create new audio but don't play
  audioElement.value = new Audio(audioUrl)
  currentlyPlaying.value = libroId
  isPlaying.value = false
  audioProgress.value = 0
  audioDuration.value = 0

  audioElement.value.addEventListener('loadedmetadata', () => {
    if (audioElement.value) {
      audioDuration.value = audioElement.value.duration
    }
  })

  audioElement.value.addEventListener('play', () => {
    isPlaying.value = true
  })

  audioElement.value.addEventListener('pause', () => {
    isPlaying.value = false
  })

  audioElement.value.addEventListener('timeupdate', () => {
    if (audioElement.value) {
      audioProgress.value = audioElement.value.currentTime
    }
  })

  audioElement.value.addEventListener('ended', () => {
    isPlaying.value = false
    audioProgress.value = 0
  })
}

const stopAudio = () => {
  if (audioElement.value) {
    audioElement.value.pause()
    audioElement.value.currentTime = 0
    isPlaying.value = false
    currentlyPlaying.value = null
    audioProgress.value = 0
  }
}

const seekAudio = (event: Event, libroId: string) => {
  if (currentlyPlaying.value === libroId && audioElement.value) {
    const target = event.target as HTMLInputElement
    audioElement.value.currentTime = Number(target.value)
  }
}

const formatTime = (seconds: number) => {
  if (!seconds || isNaN(seconds)) return '0:00'
  const mins = Math.floor(seconds / 60)
  const secs = Math.floor(seconds % 60)
  return `${mins}:${secs.toString().padStart(2, '0')}`
}
</script>

<template>
  <div class="aprendamos-juntos">
    <PageHeader
      v-if="biblioteca"
      :headline="biblioteca.introduccion.titulo"
      :subheadline="biblioteca.introduccion.subtitulo"
    />

    <section class="section intro-section">
      <div class="container">
        <p v-if="biblioteca" class="intro-text">
          {{ biblioteca.introduccion.descripcion }}
        </p>
      </div>
    </section>

    <section class="section biblioteca-section">
      <div class="container">
        <div v-if="biblioteca" class="autores-accordion">
          <div 
            v-for="autor in biblioteca.autores" 
            :key="autor.id"
            class="autor-item"
            :class="{ expanded: isAutorExpanded(autor.id) }"
          >
            <button 
              class="autor-header"
              @click="toggleAutor(autor.id)"
              :aria-expanded="isAutorExpanded(autor.id)"
            >
              <div class="autor-info">
                <span class="autor-avatar">{{ autor.iniciales }}</span>
                <div class="autor-text">
                  <h3 class="autor-nombre">{{ autor.nombre }}</h3>
                  <p class="autor-libros-count">
                    {{ autor.libros.length }} {{ autor.libros.length === 1 ? 'libro' : 'libros' }} disponible{{ autor.libros.length === 1 ? '' : 's' }}
                  </p>
                </div>
              </div>
              <span class="accordion-icon" :class="{ rotated: isAutorExpanded(autor.id) }">
                <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                  <polyline points="6 9 12 15 18 9"></polyline>
                </svg>
              </span>
            </button>

            <div class="autor-content" v-show="isAutorExpanded(autor.id)">
              <p class="autor-descripcion">{{ autor.descripcion }}</p>
              
              <!-- Audio Resumen Card -->
              <div v-if="autor.audioResumen" class="resumen-card" :id="`resumen-${autor.id}`">
                <div class="resumen-header">
                  <div class="resumen-title-section">
                    <span class="resumen-icon">🎧</span>
                    <h4 class="resumen-titulo">{{ autor.audioResumen.titulo }}</h4>
                  </div>
                  <button 
                    class="share-btn"
                    @click="shareLink(autor.id, 'resumen', autor.audioResumen.titulo)"
                    :title="copiedLink === `resumen-${autor.id}` ? '¡Link copiado!' : 'Compartir link'"
                  >
                    <svg v-if="copiedLink === `resumen-${autor.id}`" width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                      <polyline points="20 6 9 17 4 12"></polyline>
                    </svg>
                    <svg v-else width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                      <circle cx="18" cy="5" r="3"></circle>
                      <circle cx="6" cy="12" r="3"></circle>
                      <circle cx="18" cy="19" r="3"></circle>
                      <line x1="8.59" y1="13.51" x2="15.42" y2="17.49"></line>
                      <line x1="15.41" y1="6.51" x2="8.59" y2="10.49"></line>
                    </svg>
                    <span class="share-text">{{ copiedLink === `resumen-${autor.id}` ? '¡Copiado!' : 'Compartir' }}</span>
                  </button>
                </div>

                <!-- Audio Player for Resumen -->
                <div class="libro-player" v-if="currentlyPlaying === `resumen-${autor.id}`">
                  <div class="player-controls">
                    <button 
                      class="player-btn play-btn"
                      @click="playAudio(`resumen-${autor.id}`, autor.audioResumen.audio)"
                      :title="isPlaying ? 'Pausar' : 'Reproducir'"
                    >
                      <svg v-if="isPlaying" width="20" height="20" viewBox="0 0 24 24" fill="currentColor">
                        <rect x="6" y="4" width="4" height="16"></rect>
                        <rect x="14" y="4" width="4" height="16"></rect>
                      </svg>
                      <svg v-else width="20" height="20" viewBox="0 0 24 24" fill="currentColor">
                        <polygon points="5 3 19 12 5 21 5 3"></polygon>
                      </svg>
                    </button>
                    <button 
                      class="player-btn stop-btn"
                      @click="stopAudio"
                      title="Detener"
                    >
                      <svg width="18" height="18" viewBox="0 0 24 24" fill="currentColor">
                        <rect x="4" y="4" width="16" height="16"></rect>
                      </svg>
                    </button>
                  </div>
                  <div class="player-progress">
                    <input 
                      type="range" 
                      class="progress-bar"
                      :value="audioProgress"
                      :max="audioDuration"
                      @input="seekAudio($event, `resumen-${autor.id}`)"
                    />
                    <div class="player-time">
                      <span>{{ formatTime(audioProgress) }}</span>
                      <span>{{ formatTime(audioDuration) }}</span>
                    </div>
                  </div>
                </div>

                <div class="resumen-actions">
                  <button 
                    class="action-btn listen-btn"
                    @click="playAudio(`resumen-${autor.id}`, autor.audioResumen.audio)"
                    :class="{ active: currentlyPlaying === `resumen-${autor.id}` && isPlaying }"
                  >
                    <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                      <path d="M9 18V5l12-2v13"></path>
                      <circle cx="6" cy="18" r="3"></circle>
                      <circle cx="18" cy="16" r="3"></circle>
                    </svg>
                    <span>{{ currentlyPlaying === `resumen-${autor.id}` && isPlaying ? 'Reproduciendo...' : 'Escuchar resumen' }}</span>
                  </button>

                  <a 
                    :href="autor.audioResumen.audio" 
                    download 
                    class="action-btn download-btn"
                  >
                    <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                      <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"></path>
                      <polyline points="7 10 12 15 17 10"></polyline>
                      <line x1="12" y1="15" x2="12" y2="3"></line>
                    </svg>
                    <span>Descargar audio</span>
                  </a>
                </div>
              </div>
              
              <div class="libros-list">
                <div 
                  v-for="libro in autor.libros" 
                  :key="libro.id"
                  :id="`libro-${libro.id}`"
                  class="libro-card"
                >
                  <div class="libro-header">
                    <div class="libro-title-section">
                      <span class="libro-icon">📖</span>
                      <h4 class="libro-titulo">{{ libro.titulo }}</h4>
                    </div>
                    <button 
                      class="share-btn"
                      @click="shareLink(autor.id, libro.id, libro.titulo)"
                      :title="copiedLink === libro.id ? '¡Link copiado!' : 'Compartir link'"
                    >
                      <svg v-if="copiedLink === libro.id" width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                        <polyline points="20 6 9 17 4 12"></polyline>
                      </svg>
                      <svg v-else width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                        <circle cx="18" cy="5" r="3"></circle>
                        <circle cx="6" cy="12" r="3"></circle>
                        <circle cx="18" cy="19" r="3"></circle>
                        <line x1="8.59" y1="13.51" x2="15.42" y2="17.49"></line>
                        <line x1="15.41" y1="6.51" x2="8.59" y2="10.49"></line>
                      </svg>
                      <span class="share-text">{{ copiedLink === libro.id ? '¡Copiado!' : 'Compartir' }}</span>
                    </button>
                  </div>

                  <!-- Audio Player -->
                  <div class="libro-player" v-if="currentlyPlaying === libro.id">
                    <div class="player-controls">
                      <button 
                        class="player-btn play-btn"
                        @click="playAudio(libro.id, libro.audio)"
                        :title="isPlaying ? 'Pausar' : 'Reproducir'"
                      >
                        <svg v-if="isPlaying" width="20" height="20" viewBox="0 0 24 24" fill="currentColor">
                          <rect x="6" y="4" width="4" height="16"></rect>
                          <rect x="14" y="4" width="4" height="16"></rect>
                        </svg>
                        <svg v-else width="20" height="20" viewBox="0 0 24 24" fill="currentColor">
                          <polygon points="5 3 19 12 5 21 5 3"></polygon>
                        </svg>
                      </button>
                      <button 
                        class="player-btn stop-btn"
                        @click="stopAudio"
                        title="Detener"
                      >
                        <svg width="18" height="18" viewBox="0 0 24 24" fill="currentColor">
                          <rect x="4" y="4" width="16" height="16"></rect>
                        </svg>
                      </button>
                    </div>
                    <div class="player-progress">
                      <input 
                        type="range" 
                        class="progress-bar"
                        :value="audioProgress"
                        :max="audioDuration"
                        @input="seekAudio($event, libro.id)"
                      />
                      <div class="player-time">
                        <span>{{ formatTime(audioProgress) }}</span>
                        <span>{{ formatTime(audioDuration) }}</span>
                      </div>
                    </div>
                  </div>

                  <div class="libro-actions">
                    <button 
                      class="action-btn listen-btn"
                      @click="playAudio(libro.id, libro.audio)"
                      :class="{ active: currentlyPlaying === libro.id && isPlaying }"
                    >
                      <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                        <path d="M9 18V5l12-2v13"></path>
                        <circle cx="6" cy="18" r="3"></circle>
                        <circle cx="18" cy="16" r="3"></circle>
                      </svg>
                      <span>{{ currentlyPlaying === libro.id && isPlaying ? 'Reproduciendo...' : 'Escuchar resumen' }}</span>
                    </button>

                    <a 
                      :href="libro.audio" 
                      download 
                      class="action-btn download-btn"
                    >
                      <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                        <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"></path>
                        <polyline points="7 10 12 15 17 10"></polyline>
                        <line x1="12" y1="15" x2="12" y2="3"></line>
                      </svg>
                      <span>Descargar audio</span>
                    </a>

                    <a 
                      :href="libro.pdf" 
                      download 
                      class="action-btn pdf-btn"
                    >
                      <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                        <path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"></path>
                        <polyline points="14 2 14 8 20 8"></polyline>
                        <line x1="16" y1="13" x2="8" y2="13"></line>
                        <line x1="16" y1="17" x2="8" y2="17"></line>
                        <polyline points="10 9 9 9 8 9"></polyline>
                      </svg>
                      <span>Descargar PDF</span>
                    </a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <!-- Loading state -->
        <div v-else class="loading">
          <p>Cargando biblioteca...</p>
        </div>
      </div>
    </section>
  </div>
</template>

<style scoped>
.intro-section {
  background: var(--color-background);
  padding: 2rem 0 1rem;
}

.intro-text {
  max-width: 800px;
  margin: 0 auto;
  text-align: center;
  font-size: 1.125rem;
  color: var(--color-text-light);
  line-height: 1.8;
}

.biblioteca-section {
  background: var(--color-background);
  padding-top: 1rem;
}

.autores-accordion {
  display: flex;
  flex-direction: column;
  gap: 1rem;
  max-width: 900px;
  margin: 0 auto;
}

.autor-item {
  background: var(--color-background-alt);
  border-radius: 12px;
  border: 1px solid var(--color-border);
  overflow: hidden;
  transition: all 0.3s ease;
}

.autor-item:hover {
  border-color: var(--color-primary);
}

.autor-item.expanded {
  border-color: var(--color-primary);
  box-shadow: 0 4px 20px rgba(242, 180, 0, 0.15);
}

.autor-header {
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 1.25rem 1.5rem;
  background: none;
  border: none;
  cursor: pointer;
  text-align: left;
  transition: background-color 0.2s ease;
}

.autor-header:hover {
  background-color: rgba(242, 180, 0, 0.05);
}

.autor-info {
  display: flex;
  align-items: center;
  gap: 1rem;
}

.autor-avatar {
  width: 48px;
  height: 48px;
  background: linear-gradient(135deg, var(--color-primary) 0%, var(--color-primary-dark) 100%);
  color: var(--color-text);
  font-weight: 700;
  font-size: 1.25rem;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
}

.autor-text {
  display: flex;
  flex-direction: column;
  gap: 0.25rem;
}

.autor-nombre {
  font-size: 1.125rem;
  font-weight: 600;
  color: var(--color-text);
  margin: 0;
}

.autor-libros-count {
  font-size: 0.875rem;
  color: var(--color-muted);
  margin: 0;
}

.accordion-icon {
  color: var(--color-muted);
  transition: transform 0.3s ease;
  display: flex;
  align-items: center;
  justify-content: center;
}

.accordion-icon.rotated {
  transform: rotate(180deg);
}

.autor-content {
  padding: 0 1.5rem 1.5rem;
  animation: slideDown 0.3s ease;
}

@keyframes slideDown {
  from {
    opacity: 0;
    transform: translateY(-10px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

.autor-descripcion {
  color: var(--color-text-light);
  line-height: 1.7;
  margin-bottom: 1.5rem;
  padding-bottom: 1.5rem;
  border-bottom: 1px solid var(--color-border);
}

/* Resumen Card - destacado antes de los libros */
.resumen-card {
  background: linear-gradient(135deg, rgba(242, 180, 0, 0.08) 0%, rgba(242, 180, 0, 0.03) 100%);
  border-radius: 12px;
  padding: 1.5rem;
  border: 2px solid var(--color-primary);
  margin-bottom: 2rem;
  box-shadow: 0 4px 16px rgba(242, 180, 0, 0.12);
}

.resumen-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 0.75rem;
  margin-bottom: 1rem;
}

.resumen-title-section {
  display: flex;
  align-items: center;
  gap: 0.75rem;
}

.resumen-icon {
  font-size: 1.75rem;
}

.resumen-titulo {
  font-size: 1.125rem;
  font-weight: 600;
  color: var(--color-text);
  margin: 0;
}

.resumen-actions {
  display: flex;
  flex-wrap: wrap;
  gap: 0.75rem;
}

.libros-list {
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.libro-card {
  background: var(--color-background);
  border-radius: 10px;
  padding: 1.25rem;
  border: 1px solid var(--color-border);
}

.libro-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 0.75rem;
  margin-bottom: 1rem;
}

.libro-title-section {
  display: flex;
  align-items: center;
  gap: 0.75rem;
}

.libro-icon {
  font-size: 1.5rem;
}

.libro-titulo {
  font-size: 1rem;
  font-weight: 600;
  color: var(--color-text);
  margin: 0;
}

.share-btn {
  display: inline-flex;
  align-items: center;
  gap: 0.375rem;
  padding: 0.5rem 0.75rem;
  font-size: 0.8125rem;
  font-weight: 500;
  color: var(--color-muted);
  background: transparent;
  border: 1px solid var(--color-border);
  border-radius: 6px;
  cursor: pointer;
  transition: all 0.2s ease;
  white-space: nowrap;
}

.share-btn:hover {
  color: var(--color-primary-dark);
  border-color: var(--color-primary);
  background: rgba(242, 180, 0, 0.05);
}

.share-btn svg {
  flex-shrink: 0;
}

.share-text {
  display: inline;
}

.libro-player {
  background: var(--color-background-alt);
  border-radius: 8px;
  padding: 1rem;
  margin-bottom: 1rem;
  border: 1px solid var(--color-primary);
}

.player-controls {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  margin-bottom: 0.75rem;
}

.player-btn {
  width: 40px;
  height: 40px;
  border-radius: 50%;
  border: none;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
  transition: all 0.2s ease;
}

.play-btn {
  background: var(--color-primary);
  color: var(--color-text);
}

.play-btn:hover {
  background: var(--color-primary-dark);
  transform: scale(1.05);
}

.stop-btn {
  background: var(--color-border);
  color: var(--color-text-light);
}

.stop-btn:hover {
  background: var(--color-muted);
  color: white;
}

.player-progress {
  flex: 1;
}

.progress-bar {
  width: 100%;
  height: 6px;
  border-radius: 3px;
  appearance: none;
  background: var(--color-border);
  cursor: pointer;
}

.progress-bar::-webkit-slider-thumb {
  appearance: none;
  width: 14px;
  height: 14px;
  border-radius: 50%;
  background: var(--color-primary);
  cursor: pointer;
}

.progress-bar::-moz-range-thumb {
  width: 14px;
  height: 14px;
  border-radius: 50%;
  background: var(--color-primary);
  cursor: pointer;
  border: none;
}

.player-time {
  display: flex;
  justify-content: space-between;
  font-size: 0.75rem;
  color: var(--color-muted);
  margin-top: 0.5rem;
}

.libro-actions {
  display: flex;
  flex-wrap: wrap;
  gap: 0.75rem;
}

.action-btn {
  display: inline-flex;
  align-items: center;
  gap: 0.5rem;
  padding: 0.625rem 1rem;
  font-size: 0.875rem;
  font-weight: 500;
  border-radius: 8px;
  border: none;
  cursor: pointer;
  text-decoration: none;
  transition: all 0.2s ease;
}

.listen-btn {
  background: var(--color-primary);
  color: var(--color-text);
}

.listen-btn:hover {
  background: var(--color-primary-dark);
  transform: translateY(-1px);
}

.listen-btn.active {
  background: var(--color-text);
  color: white;
}

.download-btn {
  background: var(--color-background-alt);
  color: var(--color-text);
  border: 1px solid var(--color-border);
}

.download-btn:hover {
  background: var(--color-text);
  color: white;
  border-color: var(--color-text);
}

.pdf-btn {
  background: #dc2626;
  color: white;
}

.pdf-btn:hover {
  background: #b91c1c;
  transform: translateY(-1px);
}

.loading {
  text-align: center;
  padding: 3rem;
  color: var(--color-muted);
}

@media (max-width: 768px) {
  .autor-header {
    padding: 1rem;
  }

  .autor-avatar {
    width: 40px;
    height: 40px;
    font-size: 1rem;
  }

  .autor-nombre {
    font-size: 1rem;
  }

  .autor-content {
    padding: 0 1rem 1rem;
  }

  .libro-card {
    padding: 1rem;
  }

  .libro-header {
    flex-direction: column;
    align-items: flex-start;
    gap: 0.75rem;
  }

  .share-btn {
    width: 100%;
    justify-content: center;
  }

  .libro-actions {
    flex-direction: column;
  }

  .action-btn {
    width: 100%;
    justify-content: center;
  }
}
</style>
