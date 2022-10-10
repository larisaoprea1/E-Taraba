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
    GET_PRODUCT(state, product){
      state.product = product;
    }
  },
  actions: {
    async fetchProducts({ commit }) {
      return await ProductServices.getProducts()
        .then((res) => {
          commit("GET_PRODUCTS", res.data);
        })
        .catch((err) => {
          throw err;
        });
    },
    fetchProduct({ commit, state }, id) {
      const existingProduct = state.products.find((product) => product.id == id);
      if (existingProduct) {
        commit("GET_PRODUCT", existingProduct);
      } else {
        return ProductServices.getProduct(id)
          .then((res) => {
            commit("GET_PRODUCT", res.data);
          })
          .catch((err) => {
            throw err;
          });
      }
    },
  },
};
