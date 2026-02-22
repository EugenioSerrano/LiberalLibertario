import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

/* import the fontawesome core */
import { library } from '@fortawesome/fontawesome-svg-core'

/* import font awesome icon component */
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

/* import specific icons */
import { 
  faPersonRunning,
  faBalanceScale,
  faLandmark,
  faUser,
  faShieldHalved,
  faGavel,
  faBriefcase,
  faKey,
  faStoreSlash,
  faSitemap,
  faGraduationCap,
  faHandPeace
} from '@fortawesome/free-solid-svg-icons'

/* add icons to the library */
library.add(
  faPersonRunning,
  faBalanceScale,
  faLandmark,
  faUser,
  faShieldHalved,
  faGavel,
  faBriefcase,
  faKey,
  faStoreSlash,
  faSitemap,
  faGraduationCap,
  faHandPeace
)

const app = createApp(App)

app.component('font-awesome-icon', FontAwesomeIcon)

app.use(createPinia())
app.use(router)

app.mount('#app')
