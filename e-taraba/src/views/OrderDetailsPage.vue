<template>
  <div v-if="order">
    Order: {{ order.id }}
    <div>
      Customer infomation order:
      <p>Order by: {{ order.firstName }} {{ order.lastName }}</p>
      <p>Address: {{order.address}}</p>
      <p>Country: {{order.country}}</p>
      <p>City: {{order.city}}</p>
      <p>Phone number: {{order.phoneNumber}}</p>
    </div>

    <OrderProductsCard
      v-for="orderProduct in orderProducts"
      :key="orderProduct.id"
      :orderProduct="orderProduct"
    />
    Total order price: {{ order.total }} lei
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
