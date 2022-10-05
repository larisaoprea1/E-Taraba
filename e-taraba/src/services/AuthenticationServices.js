import axios from 'axios'

const apiClient = axios.create({
  baseURL: 'https://localhost:7255/api/user',
  withCredentials: false,
  headers: {
    Accept: 'application/json',
    'Content-Type': 'application/json'
  }
})

export default {
    //register
    registerUser(user){
      return apiClient.post("/register",{
        userName: user.userName,
        email: user.email,
        firstName: user.firstName,
        lastName: user.lastName,
        phoneNumber:user.phoneNumber,
        profileImageSrc: "https://nationaltoday.com/wp-content/uploads/2020/08/international-cat-day.jpg",
        password: user.password
      });
    },
    //login
    loginUser(user){
      return apiClient.post("/login",{
        email: user.email,
        password: user.password
      })
      .then(res => {
        if(res.data.accessToken){
          localStorage.setItem('user', JSON.stringify(res.data));
        }
        return res.data;
      });
    },
    //logout
    logout() {
      localStorage.removeItem('user');
    }
}