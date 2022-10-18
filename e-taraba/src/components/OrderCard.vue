<template>
  <div class="_order_container">
    <h4>Order number: {{ orderProduct.id }}</h4>
    <p>
      Order placed at {{ orderCreatedDate }} with the total of
      {{ orderProduct.total }} lei.
    </p>
    <p>Made by {{ orderProduct.firstName }} {{ orderProduct.lastName }}.</p>
    <router-link
    :to="{ name: 'OrderDetailsPage', params: { id: order.id } }"
  > Order Details</router-link>
  </div>
</template>

<script>
import moment from "moment";
export default {
  props: {
    orderProduct: {
      type: Object,
    },
  },
  computed: {
    orderCreatedDate() {
      return moment(this.orderProduct.createAt).format("DD-MM-YYYY");
    },
  },
};
</script>
<style scoped>
._order_container {
  margin: 10px;
  padding: 10px;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  border: 1px solid rgb(202, 202, 202);
  border-radius: 8px;
}
</style>
