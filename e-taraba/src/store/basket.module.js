import BasketService from "@/services/BasketService";
const initialState = {
  products: [],
  basket: {},
  basketProducts: [],
  basketProduct: {},
};
export const basket = {
  namespaced: true,
  state: initialState,
  mutations: {
    GET_BASKET(state, basket) {
      state.basket = basket;
    },
    ADD_PRODUCT(state, product) { 
      state.basket.basketProducts.push(product);
    },
    DECREASE_PRODUCT_QUANTITY(state, basketProduct){
      var basketProductToFind = state.basket.basketProducts.find(
        (b) => b.id == basketProduct
      );
      console.log(basketProductToFind);
     basketProductToFind.quantity =  basketProductToFind.quantity -1;
     basketProductToFind.price = basketProductToFind.product.price * basketProductToFind.quantity;
    },
    INCREASE_PRODUCT_QUANTITY(state, basketProduct){
      var basketProductToFind = state.basket.basketProducts.find(
        (b) => b.id == basketProduct
      );
     basketProductToFind.quantity =  basketProductToFind.quantity +1;
     basketProductToFind.price = basketProductToFind.product.price * basketProductToFind.quantity
    },
    DELETE_BASKET_PRODUCT(state, basketProduct) {
      var index = state.basket.basketProducts.findIndex(
        (b) => b.id == basketProduct
      );
      state.basket.basketProducts.splice(index, 1);
    },
    EMPTY_BASKET(state){
      state.basket.basketProducts.splice(0, state.basket.basketProducts.length)
    }
  },
  actions: {
    async addProductToCartEvent({ commit }, { userid, productid, count }) {
      return await BasketService.addProductToCart(userid, productid, count)
        .then((res) => {
          commit("ADD_PRODUCT", res.data);
        })
        .catch((err) => {
          console.log(err);
        });
    },
    async fetchBasket({ commit }, id) {
      return await BasketService.getBasket(id)
        .then((res) => { 
          commit("GET_BASKET", res.data);
        })
        .catch((err) => {
          console.log(err);
        });
    },
    async decreaseQuantityForBasketProduct({commit}, { productid, quantity }) {
      return await BasketService.updateProductQuantity(productid, quantity)
      .then(()=>{
        commit("DECREASE_PRODUCT_QUANTITY", productid)
      });
    },
    async increaseQuantityForBasketProduct({commit}, { productid, quantity }) {
      return await BasketService.updateProductQuantity(productid, quantity)
      .then(()=>{
        commit("INCREASE_PRODUCT_QUANTITY", productid)
      });
    },
    async removeBasketProductEvent({ commit }, id) {
      return await BasketService.removeBasketProduct(id).then(() => {
        commit("DELETE_BASKET_PRODUCT", id);
      });
    },
    async emptyBasketProductsEvent({commit}, userid){
      return await BasketService.emptyCartProducts(userid).then(()=>{
        commit("EMPTY_BASKET", userid)
      })
    }
  },
};
