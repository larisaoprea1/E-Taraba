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
        profileImageSrc: user.profileImageSrc,
        password: user.password
      });
    },
    //login
    loginUser(user){
      return apiClient.post("/login",{
        email: user.email,
        password: user.password
      })
      .then(response => {
        if (response.data.token) {
          localStorage.setItem('user', JSON.stringify(response.data));
        }

        return response.data;
      });
    },
    //logout
    logout() {
      localStorage.clear();
    }
}