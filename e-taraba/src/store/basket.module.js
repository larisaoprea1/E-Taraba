import BasketService from "@/services/BasketService";

export const basket = {
    namespaced: true,
    actions:{
        async addProductToCartEvent({userid,productid}){
            return await BasketService.addProductToCart(userid, productid, 1);
        }
    }
}