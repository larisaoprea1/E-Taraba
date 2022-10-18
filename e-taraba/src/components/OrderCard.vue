<template>
  <div class="_order_container">
    <h4>Order number: {{ order.id }}</h4>
    <p>
      Order placed at {{ orderCreatedDate }} with the total of
      {{ order.total }} lei.
    </p>
    <p>Made by {{ order.firstName }} {{ order.lastName }}.</p>
    <router-link
    :to="{ name: 'OrderDetailsPage', params: { id: order.id } }"
  > Order Details</router-link>
  </div>
</template>

<script>
import moment from "moment";
export default {
  props: {
    order: {
      type: Object,
      required: true,
    },
  },
  computed: {
    orderCreatedDate() {
      return moment(this.order.createAt).format("DD-MM-YYYY");
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
