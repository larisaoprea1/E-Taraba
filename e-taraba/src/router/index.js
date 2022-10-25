import { createRouter, createWebHashHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import RegisterPage from '../views/RegisterPage.vue'
import LoginPage from '../views/LoginPage.vue'
import ProductPage from '../views/ProductPage.vue'
import ProfilePage from '../views/ProfilePage.vue'
import CartPage from '../views/CartPage.vue'
import OrderPage from '../views/OrderPage.vue'
import OrderDetailsPage from '../views/OrderDetailsPage.vue'
import AddProductsPage from '../views/AddProductsPage.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/addproducts',
    name: 'AddProducts',
    component: AddProductsPage
  },
  {
    path: '/register',
    name: 'register',
    component: RegisterPage
  },
  {
    path: '/login',
    name: 'login',
    component: LoginPage
  },
  {
    path: '/profile',
    name: 'profile',
    component: ProfilePage
  },
  {
    path: '/product/:id',
    name: 'ProductPage',
    props: true,
    component: ProductPage
  },
  {
    path: '/basket',
    name: 'CartPage',
    component: CartPage
  },
  {
    path: '/order',
    name: 'OrderPage',
    component: OrderPage
  },
  {
    path: '/order/:id',
    name: 'OrderDetailsPage',
    props: true,
    component: OrderDetailsPage
  },
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
