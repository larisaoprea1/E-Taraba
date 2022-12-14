import axios from "axios";

const apiClient = axios.create({
  baseURL: "https://localhost:7255/api/basket",
  withCredentials: false,
  headers: {
    Accept: "application/json",
    "Content-Type": "application/json",
  },
});

export default {
    getBasket(id){
      return apiClient.get(`/${id}`)
    },
    addProductToCart(userid,productid,count){
        return apiClient.post(`/user/${userid}/product/${productid}/count/${count}`)
    },
    updateProductQuantity(basketProductId, quantity){
      return apiClient.put(`/updatequantity/${basketProductId}/quantity/${quantity}`)
    },
    removeBasketProduct(id){
      return apiClient.delete(`/${id}`)
    },
    emptyCartProducts(userid){
      return apiClient.delete(`emptycart/${userid}`)
    }
}