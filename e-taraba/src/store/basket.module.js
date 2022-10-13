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
    DELETE_BASKET_PRODUCT(state, basketProduct) {
      var index = state.basketProducts.indexOf(
        basketProduct
      );
      state.basketProducts.splice(index, 1);
    },
  },
  actions: {
    async addProductToCartEvent(state, { userid, productid, count }) {
      return await BasketService.addProductToCart(userid, productid, count);
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
    async removeBasketProductEvent({ commit }, id) {
      return await BasketService.removeBasketProduct(id).then(() => {
        commit("DELETE_BASKET_PRODUCT", id);
        location.reload();
      });
    },
  },
};
