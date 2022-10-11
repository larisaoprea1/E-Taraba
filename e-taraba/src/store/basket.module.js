import BasketService from "@/services/BasketService";
const initialState ={
    products: []
}
export const basket = {
    namespaced: true,
    state: initialState,
    actions:{
        async addProductToCartEvent(state, {userid,productid}){
            return await BasketService.addProductToCart(userid, productid, 1);
        }
    }
}