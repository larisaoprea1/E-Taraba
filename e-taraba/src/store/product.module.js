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
    },
    ADD_PRODUCT(state, product){
      state.products.push(product);
    }
  },
  actions: {
    async fetchProducts({ commit }, searchProduct) {
      return await ProductServices.getProducts(searchProduct)
        .then((res) => {
          commit("GET_PRODUCTS", res.data);
        })
        .catch((err) => {
          throw err;
        });
    },
    async fetchProduct({ commit, state }, id) {
      const existingProduct = await state.products.find((product) => product.id == id);
      if (existingProduct) {
        commit("GET_PRODUCT", existingProduct);
      } else {
        return await ProductServices.getProduct(id)
          .then((res) => {
            commit("GET_PRODUCT", res.data);
          })
          .catch((err) => {
            throw err;
          });
      }
    },
    async addProductEvent({commit}, product ){
      return await ProductServices.addProduct(product)
      .then(() => {
        commit("ADD_PRODUCT", product);
      })
      .catch((err) => {
        console.log(err);
      });
    }
  },
};
