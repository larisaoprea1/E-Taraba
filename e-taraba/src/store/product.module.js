import ProductServices from "@/services/ProductServices";

const initialState = {
  products: [],
  product: {},
};

export const product = {
  namespaced: true,
  state: initialState,
  mutations: {
    GET_PRODUCTS(state, products) {
      state.products = products;
    },
  },
  actions: {
    fetchProducts({ commit }) {
      return ProductServices.getProducts()
        .then((res) => {
          commit("GET_PRODUCTS", res.data);
        })
        .then((res) => {
          console.log(res);
        })
        .catch((err) => { 
          throw err;
        });
    },
  },
};
