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
    // UPDATE_PRODUCT(state, basketProduct){

    // },
    DELETE_BASKET_PRODUCT(state, basketProduct) {
      var index = state.basket.basketProducts.findIndex(
        (b) => b.id == basketProduct
      );
      state.basket.basketProducts.splice(index, 1);
    },
  },
  actions: {
    async addProductToCartEvent({ commit }, { userid, productid, count }) {
      return await BasketService.addProductToCart(
        userid,
        productid,
        count
      ).then((res) => {
        commit("ADD_PRODUCT", res.data)
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
    async updateQuantityForBasketProduct(state, {productid, quantity}){
        return await BasketService.updateProductQuantity(
          productid,
          quantity
        )
    },
    async removeBasketProductEvent({ commit }, id) {
      return await BasketService.removeBasketProduct(id).then(() => {
        commit("DELETE_BASKET_PRODUCT", id);
      });
    },
  },
};
