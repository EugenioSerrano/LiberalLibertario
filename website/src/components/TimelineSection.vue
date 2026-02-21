<script setup lang="ts">
interface TimelineItem {
  title: string
  text: string
}

defineProps<{
  items: TimelineItem[]
}>()
</script>

<template>
  <section class="section timeline-section">
    <div class="container">
      <div class="timeline">
        <div 
          v-for="(item, index) in items" 
          :key="index" 
          class="timeline-item"
        >
          <div class="timeline-marker">
            <span class="timeline-number">{{ index + 1 }}</span>
          </div>
          <div class="timeline-content">
            <h3 class="timeline-title">{{ item.title }}</h3>
            <p class="timeline-text">{{ item.text }}</p>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<style scoped>
.timeline-section {
  background: var(--color-background);
}

.timeline {
  position: relative;
  max-width: 800px;
  margin: 0 auto;
}

.timeline::before {
  content: '';
  position: absolute;
  left: 30px;
  top: 0;
  bottom: 0;
  width: 3px;
  background: linear-gradient(to bottom, var(--color-primary), var(--color-primary-dark));
  border-radius: 3px;
}

.timeline-item {
  display: flex;
  gap: 2rem;
  padding-bottom: 3rem;
  position: relative;
}

.timeline-item:last-child {
  padding-bottom: 0;
}

.timeline-marker {
  flex-shrink: 0;
  width: 60px;
  height: 60px;
  background: var(--color-primary);
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  position: relative;
  z-index: 1;
  box-shadow: 0 4px 16px rgba(242, 180, 0, 0.3);
}

.timeline-number {
  font-family: var(--font-heading);
  font-size: 1.25rem;
  font-weight: 700;
  color: var(--color-text);
}

.timeline-content {
  flex: 1;
  background: var(--color-background-alt);
  padding: 1.5rem 2rem;
  border-radius: 12px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.05);
  border: 1px solid var(--color-border);
}

.timeline-title {
  font-size: 1.25rem;
  margin-bottom: 0.75rem;
  color: var(--color-text);
}

.timeline-text {
  color: var(--color-muted);
  margin: 0;
  line-height: 1.7;
}

@media (max-width: 640px) {
  .timeline::before {
    left: 20px;
  }

  .timeline-item {
    gap: 1.25rem;
  }

  .timeline-marker {
    width: 40px;
    height: 40px;
  }

  .timeline-number {
    font-size: 1rem;
  }

  .timeline-content {
    padding: 1.25rem;
  }
}
</style>