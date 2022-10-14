import OrderService from "@/services/OrderService";

const initialState = {
  orders: [],
  order: {},
};
export const order = {
  namespaced: true,
  state: initialState,
  mutations: {
    ADD_ORDER(state, order) {
      state.orders.push(order);
    },
  },
  actions: {
    async saveOrderEvent({ commit }, { userid, order }) {
      return await OrderService.saveOrder(userid, order)
      .then(() =>{
        commit('ADD_ORDER', order)
        console.log("111");
      })
      .catch(err =>{
        console.log(err);
      })
    },
  },
};
