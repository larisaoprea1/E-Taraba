<template>
<nav>
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link> |
    <router-link to="/register">Register</router-link> |
    <router-link to="/login">Login</router-link>
  </nav>
  <router-view/>
</template>

<script>
export default {
  name: 'NavBar',
}
</script>


<style scoped>

</style>
