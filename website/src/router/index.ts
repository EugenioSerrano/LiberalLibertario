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
      meta: { title: 'Sitio en Mantenimiento - Libertarios Traslasierra' }
    },
    {
      path: '/',
      name: 'home',
      component: HomeView,
      meta: { title: 'Libertarios Traslasierra' }
    },
    {
      path: '/quienes-somos',
      name: 'quienes-somos',
      component: () => import('../views/QuienesSomosView.vue'),
      meta: { title: 'Quiénes Somos - Libertarios Traslasierra' }
    },
    {
      path: '/origen',
      name: 'origen',
      component: () => import('../views/OrigenView.vue'),
      meta: { title: 'De Dónde Venimos - Libertarios Traslasierra' }
    },
    {
      path: '/principios',
      name: 'principios',
      component: () => import('../views/PrincipiosView.vue'),
      meta: { title: 'Principios - Libertarios Traslasierra' }
    },
    {
      path: '/que-hacemos',
      name: 'que-hacemos',
      component: () => import('../views/QueHacemosView.vue'),
      meta: { title: 'Qué Hacemos - Libertarios Traslasierra' }
    },
    {
      path: '/como-trabajamos',
      name: 'como-trabajamos',
      component: () => import('../views/ComoTrabajamosView.vue'),
      meta: { title: 'Cómo Trabajamos - Libertarios Traslasierra' }
    },
    {
      path: '/sumate',
      name: 'sumate',
      component: () => import('../views/SumateView.vue'),
      meta: { title: 'Sumate - Libertarios Traslasierra' }
    },
    {
      path: '/aprendamos-juntos',
      name: 'aprendamos-juntos',
      component: () => import('../views/AprendamosJuntosView.vue'),
      meta: { title: 'Aprendamos Juntos - Libertarios Traslasierra' }
    },
    {
      path: '/contacto',
      name: 'contacto',
      component: () => import('../views/ContactoView.vue'),
      meta: { title: 'Contacto - Libertarios Traslasierra' }
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
  
  document.title = (to.meta.title as string) || 'Libertarios Traslasierra'
  next()
})

export default router
