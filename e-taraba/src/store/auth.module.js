import AuthenticationServices from "../services/AuthenticationServices";

const user = JSON.parse(localStorage.getItem("user"));
const initialState = user
  ? { status: { loggedIn: true }, user }
  : { status: { loggedIn: false }, user: null };

export const auth = {
  namespaced: true,
  state: initialState,
  mutations: {
    registerSuccess(state) {
      state.status.loggedIn = false;
    },
    registerFailure(state) {
      state.status.loggedIn = false;
    },
    loginSuccess(state, user) {
      state.status.loggedIn = true;
      state.user = user;
    },
    loginFailure(state) {
      state.status.loggedIn = false;
      state.user = null;
    },
    logout(state) {
      state.status.loggedIn = false;
      state.user = null;
    },
  },
  actions: {
    register({ commit }, user) {
      return AuthenticationServices.registerUser(user)
        .then((res) => {
          commit("registerSuccess");
          return Promise.resolve(res.data);
        })
        .catch((err) => {
          commit("registerFailure");
          return Promise.reject(err);
        });
    },
    login({ commit }, user) {
      return AuthenticationServices.loginUser(user)
        .then((user) => {
          commit("loginSuccess");
          return Promise.resolve(user);
        })
        .catch((err) => {
          commit("loginFailure");
          return Promise.reject(err);
        });
    },
    logout({commit}){
        AuthenticationServices.logout();
        commit("logout");
    }
  },
};
