import { createRouter, createWebHashHistory, RouteRecordRaw } from 'vue-router'
import HomeView from '../views/HomeView.vue';
import BingoView from '../views/BingoView.vue';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/bingo/:id',
    name: 'bingo',
    component: BingoView,
    props: true
  },
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
