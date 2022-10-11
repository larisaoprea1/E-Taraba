import { createStore } from 'vuex'
import { auth } from './auth.module'
import { product } from './product.module'
import { basket } from './basket.module'

export default createStore({
  state: {
  },
  getters: {
  },
  mutations: {
  },
  actions: {
  },
  modules: {
    auth,
    product,
    basket
  }
})
