import OrderService from "@/services/OrderService";

const initialState = {
  orders: [],
  order: {},
};
export const order = {
  namespaced: true,
  state: initialState,
  mutations: {
    GET_ORDERS(state, orders) {
      state.orders = orders;
    },
    GET_ORDER(state, order) {
      state.order = order;
    },
    ADD_ORDER(state, order) {
      state.orders.push(order);
    },
  },
  actions: {
    async fetchOrders({ commit }, userid) {
      return await OrderService.getOrders(userid)
        .then((res) => {
          commit("GET_ORDERS", res.data);
          console.log(res.data);
        })
        .catch((error) => {
          throw error;
        });
    },
    async fetchOrder({ commit }, id) {
      return await OrderService.getOrder(id)
        .then((res) => {
          commit("GET_ORDER", res.data);
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
