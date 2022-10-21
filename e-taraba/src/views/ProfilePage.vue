<template>
 
  <div class="container">
     <h1 class="mt-3">{{ currentUser.user.UserName }}`s Profile</h1>
    <nav>
      <div class="nav nav-tabs" id="nav-tab" role="tablist">
        <button
          class="nav-link active"
          id="nav-home-tab"
          data-bs-toggle="tab"
          data-bs-target="#nav-home"
          type="button"
          role="tab"
          aria-controls="nav-home"
          aria-selected="true"
        >
          Profile
        </button>
        <button
          class="nav-link"
          id="nav-profile-tab"
          data-bs-toggle="tab"
          data-bs-target="#nav-profile"
          type="button"
          role="tab"
          aria-controls="nav-profile"
          aria-selected="false"
        >
          Orders
        </button>
        <button
          class="nav-link"
          id="nav-contact-tab"
          data-bs-toggle="tab"
          data-bs-target="#nav-contact"
          type="button"
          role="tab"
          aria-controls="nav-contact"
          aria-selected="false"
        >
          Settings
        </button>
      </div>
    </nav>
    <div class="tab-content" id="nav-tabContent">
      <div
        class="tab-pane fade show active"
        id="nav-home"
        role="tabpanel"
        aria-labelledby="nav-home-tab"
      >
        <div class="container d-flex mt-5 __container">
          <div class="_image_container">
            <img :src="currentUser.user.ProfileImage" />
          </div>
          <div class="_user_container d-flex align-items-center">
            <p><span>First Name:</span> {{ currentUser.user.FirstName }}</p>
            <p><span>Last Name: </span> {{ currentUser.user.LastName }}</p>

            <p>Email:{{ currentUser.user.Email }}</p>

            <p>Username:{{ currentUser.user.UserName }}</p>
          </div>
        </div>
      </div>
      <div
        class="tab-pane fade"
        id="nav-profile"
        role="tabpanel"
        aria-labelledby="nav-profile-tab"
      >
        Your orders: 
        <OrderCard
        v-for="order in orders"
          :key="order.id"
          :order="order"           
          />
      </div>
      <div
        class="tab-pane fade"
        id="nav-contact"
        role="tabpanel"
        aria-labelledby="nav-contact-tab"
      >
        Settings
      </div>
    </div>
  </div>
</template>

<script>
import OrderCard from "@/components/OrderCard.vue";
export default {
  name: "ProfilePage",
  components: {
    OrderCard,
  },
  created() {
    this.$store.dispatch("order/fetchOrders", this.currentUser.user.Id);
  },
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    },
    orders() {
      console.log(this.$store.state.order.orders);
      return this.$store.state.order.orders;
    },
  },
};
</script>

<style scoped>
._image_container img {
  width: 100%;
}
._image_container {
  width: 300px;
  margin-left: 200px;
  margin-right: 20px;
}
._user_container {
  width: 500px;
  flex-direction: column;
  justify-content: center;
  border-left: 1px solid black;
}
</style>
