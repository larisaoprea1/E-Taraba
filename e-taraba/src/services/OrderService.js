import axios from "axios";

const apiClient = axios.create({
  baseURL: "https://localhost:7255/api/order",
  withCredentials: false,
  headers: {
    Accept: "application/json",
    "Content-Type": "application/json",
  },
});

export default{
    saveOrder(userid, order){
        return apiClient.post(`/saveorder/user/${userid}`,{
            firstName: order.firstName,
            lastName: order.lastName,
            phoneNumber: order.phoneNumber,
            email: order.email,
            address: order.address,
            city: order.city,
            country: order.country
        })
    }
}