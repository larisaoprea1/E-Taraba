import BasketService from "@/services/BasketService";
const initialState ={
    products: [],
    basket:{},
    basketProducts:[],
    basketProduct: {}
}
export const basket = {
    namespaced: true,
    state: initialState,
    mutations:{
        GET_BASKET(state, basket){
            state.basket = basket;
        }
    },
    actions:{
        async addProductToCartEvent(state, {userid,productid, count}){
            return await BasketService.addProductToCart(userid, productid, count);
        },
        async getBasket({commit, state}, id){
            const existingBasket = await state.basket.find((basket)=> basket.id == id);
            if(existingBasket){
                commit("GET_BASKET", existingBasket)
            }
            else{
                return await BasketService.getBasket(id)
                .then(res =>{
                    commit("GET_BASKET", res.data);
                })
                .catch(err=>{
                    console.log(err);
                })
            }
        }
    }
}