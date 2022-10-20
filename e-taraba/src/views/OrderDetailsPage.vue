<template>
  <div v-if="order">
    <h3 class="_title">Order: {{ order.id }}</h3>
    
    <div class="container _container"><el-card class="box-card">
      <h4>Customer infomation order:</h4>
      <p>Order by: {{ order.firstName }} {{ order.lastName }}</p>
      <p>Address: {{order.address}}</p>
      <p>Country: {{order.country}}</p>
      <p>City: {{order.city}}</p>
      <p>Phone number: {{order.phoneNumber}}</p>
    </el-card></div>
    <div class="_order_container">
    <OrderProductsCard
      v-for="orderProduct in orderProducts"
      :key="orderProduct.id"
      :orderProduct="orderProduct"
    />
    </div>
    <p class="_total_order">Total order price: {{ order.total }} lei</p>
  </div>
</template>

<script>
import OrderProductsCard from "../components/OrderProductsCard.vue";
export default {
  props: ["id"],
  name: "OrderDetailsPage",
  created() {
    this.$store.dispatch("order/fetchOrder", this.id);
  },
  computed: {
    orderProducts() {
      console.log(this.$store.state.order.order.orderProducts);
      return this.$store.state.order.order.orderProducts;
    },
    order() {
      console.log(this.$store.state.order.order);
      return this.$store.state.order.order;
    },
  },
  components: { OrderProductsCard },
};
</script>

<style scoped>
._title{
  margin-top: 10px;
  font-weight: bold;
}
.box-card {
  width: 350px;
}
._container{
  display: flex;
  justify-content: center;
  margin-top: 20px;
  margin-bottom: 20px;
}
._order_container {
  margin: 10px;
  padding: 10px;
  display: flex;
  flex-direction: row;
  justify-content: center;
  gap: 50px;
}
._total_order{
  font-size: larger;
  margin-bottom: 20px;
}
</style>
