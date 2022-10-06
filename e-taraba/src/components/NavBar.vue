<template>
  <!-- <nav>
    <router-link :to="{name: 'home'}">Home</router-link> |
    <router-link :to="{name: 'about'}">About</router-link> |
    <router-link :to="{name: 'register'}">Register</router-link> |
    <router-link :to="{name: 'login'}">Login</router-link>
  </nav>
  <router-view/> -->
  <el-menu
  :default-active="activeIndex"
    class="el-menu-demo color"
    mode="horizontal"
    text-color="#fff"
    margin-left="10px"
    background-color="#2d694f"
    active-text-color="#42b983"
  >
    <el-menu-item index="1"
    
      ><router-link :to="{name: 'home'}" class="nav-link d-flex align-items-center gap-2 ml-2">
        <font-awesome-icon icon="shopping-bag" /> E-Taraba
      </router-link></el-menu-item
    >
    <el-menu-item index="2"><router-link :to="{name: 'about'}" class="nav-link flex-grow">About</router-link></el-menu-item>
    <div class="flex-grow" />
    <el-menu-item index="3"  v-if="!currentUser"><router-link :to="{name: 'register'}" class="nav-link">Register</router-link></el-menu-item>
    <el-menu-item index="4"  v-if="!currentUser"><router-link :to="{name: 'login'}" class="nav-link">Login</router-link></el-menu-item>
    <el-menu-item index="5"  v-if="currentUser"><router-link :to="{name: 'home'}" class="nav-link">Hello, ...!</router-link></el-menu-item>
    <el-menu-item index="6"  v-if="currentUser"><a class="nav-link d-flex align-items-center gap-2" @click.prevent="logOut"><font-awesome-icon icon="sign-out-alt" />LogOut</a></el-menu-item>
  </el-menu>
  <router-view/>
</template>

<script>
export default {
  
  name: "NavBar",
  computed:{
    currentUser(){
      return this.$store.state.auth.user;
    }
  },
  methods: {
    logOut() {
      this.$store.dispatch('auth/logout');
      this.$router.push('/');
    }
  }
};
</script>

<style scoped>
  .flex-grow {
    
  flex-grow: 0.95;
}
</style>
