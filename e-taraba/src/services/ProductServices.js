import axios from "axios";

const apiClient = axios.create({
  baseURL: "https://localhost:7255/api/products",
  withCredentials: false,
  headers: {
    Accept: "application/json",
    "Content-Type": "application/json",
  },
});

export default {
  getProducts() {
    return apiClient.get();
  },
  getProduct(id){
    return apiClient.get(`/${id}`)
  }
};
