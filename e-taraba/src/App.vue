<template>
  <div>
  <NavBar/>
</div>
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
  height: 100vh;
  overflow-x: hidden;
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
@media (max-width: 550px){
  nav{
    padding: 20px;
  }
  #app{
    height: 100vh;
  }
}
</style>
