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
  getProducts(searchProduct) {
    return apiClient.get(`/?searchProduct=${searchProduct}`);
  },
  getProduct(id){
    return apiClient.get(`/${id}`)
  },
  addProduct(product){
    return apiClient.post('/addproduct', {
      name: product.name,
      description: product.description,
      productPhoto: product.productPhoto,
      quantity: product.quantity,
      price: product.price
    })
  },
};
