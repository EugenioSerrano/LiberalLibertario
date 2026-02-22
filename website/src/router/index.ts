import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import MaintenanceView from '../views/MaintenanceView.vue'

// Detectar si el modo mantenimiento está activado
const isMaintenanceMode = import.meta.env.VITE_MAINTENANCE_MODE === 'true'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/mantenimiento',
      name: 'maintenance',
      component: MaintenanceView,
      meta: { title: 'Sitio en Mantenimiento - Liberal Libertario' }
    },
    {
      path: '/',
      name: 'home',
      component: HomeView,
      meta: { title: 'Liberal Libertario' }
    },
    {
      path: '/principios',
      name: 'principios',
      component: () => import('../views/PrincipiosView.vue'),
      meta: { title: 'Principios - Liberal Libertario' }
    },
    {
      path: '/aprendamos-juntos',
      name: 'aprendamos-juntos',
      component: () => import('../views/AprendamosJuntosView.vue'),
      meta: { title: 'Biblioteca - Liberal Libertario' }
    },
    {
      path: '/contacto',
      name: 'contacto',
      component: () => import('../views/ContactoView.vue'),
      meta: { title: 'Contacto - Liberal Libertario' }
    }
  ],
  scrollBehavior(_to, _from, savedPosition) {
    if (savedPosition) {
      return savedPosition
    } else {
      return { top: 0 }
    }
  }
})

router.beforeEach((to, _from, next) => {
  // Si el modo mantenimiento está activado y no estamos en la ruta de mantenimiento
  if (isMaintenanceMode && to.name !== 'maintenance') {
    next({ name: 'maintenance' })
    return
  }
  
  // Si el modo mantenimiento está desactivado y estamos en la ruta de mantenimiento
  if (!isMaintenanceMode && to.name === 'maintenance') {
    next({ name: 'home' })
    return
  }
  
  document.title = (to.meta.title as string) || 'Liberal Libertario'
  next()
})

export default router
