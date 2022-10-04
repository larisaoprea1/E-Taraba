import AuthenticationServices from "../services/AuthenticationServices";

const user = JSON.parse(localStorage.getItem('user'));
const initialState = user
  ? { status: { loggedIn: true }, user }
  : { status: { loggedIn: false }, user: null };

export const auth = {
    namespaced: true,
    state: initialState,
    mutations:{
        registerSuccess(state) {
            state.status.loggedIn = false;
        },
          registerFailure(state) {
            state.status.loggedIn = false;
        }
    },
    actions:{
        register({ commit }, user) {
            return AuthenticationServices.registerUser(user)
            .then(res => {
                commit('registerSuccess');
                return Promise.resolve(res.data);
            })
            .catch(err =>{
                commit('registerFailure');
                return Promise.reject(err);
            })
        }
    }
}
