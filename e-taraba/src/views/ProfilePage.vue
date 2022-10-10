<template>
  <h1 class="mt-3">{{ currentUser.user.UserName }}`s Profile</h1>
  <!-- <nav>
  <div class="nav nav-tabs" id="nav-tab" role="tablist">
    <button class="nav-link active" id="nav-home-tab" data-bs-toggle="tab" data-bs-target="#nav-home" type="button" role="tab" aria-controls="nav-home" aria-selected="true">Profile</button>
    <button class="nav-link" id="nav-profile-tab" data-bs-toggle="tab" data-bs-target="#nav-profile" type="button" role="tab" aria-controls="nav-profile" aria-selected="false">Orders</button>
    <button class="nav-link" id="nav-contact-tab" data-bs-toggle="tab" data-bs-target="#nav-contact" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">Settings</button>
  </div>
</nav>
<div class="tab-content" id="nav-tabContent">
  <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab"></div>
  <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">Your orders:
      <OrderCard/></div>
  <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab"> Settings</div>
</div> -->
<div class=" container d-flex align-items-start">
  <div class="nav flex-column nav-pills me-3" id="v-pills-tab" role="tablist" aria-orientation="vertical">
    <button class="nav-link active " id="v-pills-home-tab" data-bs-toggle="pill" data-bs-target="#v-pills-home" type="button" role="tab" aria-controls="v-pills-home" aria-selected="true">Profile</button>
    <button class="nav-link" id="v-pills-profile-tab" data-bs-toggle="pill" data-bs-target="#v-pills-profile" type="button" role="tab" aria-controls="v-pills-profile" aria-selected="false">Orders</button>
    <button class="nav-link" id="v-pills-settings-tab" data-bs-toggle="pill" data-bs-target="#v-pills-settings" type="button" role="tab" aria-controls="v-pills-settings" aria-selected="false">Settings</button>
  </div>
  <div class="tab-content" id="v-pills-tabContent">
    <div class="tab-pane-success fade show active" id="v-pills-home" role="tabpanel" aria-labelledby="v-pills-home-tab"><div class="container d-flex mt-5">
    <div class="_image_container">
      <img :src="currentUser.user.ProfileImage" />
    </div>
    <div class="_user_container">
      <div class="d-flex justify-content-center">
        First Name:
        <p>{{ currentUser.user.FirstName }}</p>
      </div>
      <p>Last Name: {{ currentUser.user.LastName }}</p>
      Email:
      <p>{{ currentUser.user.Email }}</p>
      Username:
      <p>{{ currentUser.user.UserName }}</p>
      
    
    </div>
  </div></div>
    <div class="tab-pane fade" id="v-pills-profile" role="tabpanel" aria-labelledby="v-pills-profile-tab">Your orders: <OrderCard/></div>
    <div class="tab-pane fade" id="v-pills-settings" role="tabpanel" aria-labelledby="v-pills-settings-tab">Settings</div>
  </div>
</div>
  
</template>

<script>
import OrderCard from '@/components/OrderCard.vue';
export default {
  name: "ProfilePage",
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    },
  },
  components: {
    OrderCard
}
};
</script>
<style scoped>
._image_container img {
  width: 100%;
}
._image_container {
  width: 300px;
  margin-left: 200px;
}
._user_container {
  width: 500px;
}
.nav-tabs .nav-item .nav-link {
  background-color: #197248;
  color: #FFF;
}

.nav-tabs .nav-item .nav-link.active {
  color: #3a9b76;
}

.tab-content {
  border: 1px solid #dee2e6;
  border-top: transparent;
  padding: 15px;
}

.tab-content .tab-pane {
  background-color: #FFF;
  color: #1e7c58;
  min-height: 200px;
  height: auto;
}
</style>
