import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [

  {
    path: '/admin',
    name: 'Admin',
    
    component: () => import( '@/components/admin.vue')
  },
  {
    path: '/forms',
    name: 'Form',
    
    component: () => import( '@/components/form.vue')
  }
]


const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
