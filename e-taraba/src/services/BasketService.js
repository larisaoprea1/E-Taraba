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
    removeBasketProduct(id){
      return apiClient.delete(`/${id}`)
    }
}