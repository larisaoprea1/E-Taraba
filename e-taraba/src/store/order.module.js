import OrderService from "@/services/OrderService";

const initialState = {
  orders: [],
};
export const order = {
  namespaced: true,
  state: initialState,
  mutations: {
    GET_ORDERS(state, orders) {
      state.orders = orders;
    },
    ADD_ORDER(state, order) {
      state.orders.push(order);
    },
  },
  actions: {
    async fetchOrders({ commit }, userid) {
      return await OrderService.getOrders(userid)
        .then((response) => {
          commit("GET_ORDERS", response.data);
          console.log(response.data);
        })
        .catch((error) => {
          throw error;
        });
    },
    async saveOrderEvent({ commit }, { userid, order }) {
      return await OrderService.saveOrder(userid, order)
        .then(() => {
          commit("ADD_ORDER", order);
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
};
