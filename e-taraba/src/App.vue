<template>
  <NavBar/>
</template>
<script>
import NavBar from './components/NavBar.vue';

export default {
  name: 'App',
  components: {
    NavBar
  }
}
</script>
<style>
@import url('https://fonts.googleapis.com/css?family=Roboto+Condensed');
#app {
  font-family: 'Poppins', sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #000000;
  /* z-index: 1;
  background: linear-gradient(-45deg, rgb(145, 145, 145),rgb(219, 219, 219), rgb(250, 250, 250),rgb(255, 255, 255));
  background-size: 400% 400%; */
  height: 100vh;
  /* width: 100%; */
}
nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
/* @keyframes gradient {
  0% {
    background-position: 0% 50%;
  }
  50% {
    background-position: 100% 50%;
  }
  100% {
    background-position: 0% 50%;
  }
} */
@media (max-width: 550px){
  nav{
    padding: 20px;
  }
  #app{
    height: 100vh;
  }
}
</style>
