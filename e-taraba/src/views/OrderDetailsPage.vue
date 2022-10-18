<template>
  <div v-if="order">
  Order: {{order.id}}
  </div>
</template>

<script>
export default {
props: ["id"],
  created() {
    this.$store.dispatch("order/fetchOrder", this.order.id);
  },
  computed: {
    order() {
      console.log(this.$store.state.order.order);
      return this.$store.state.order.order;
    },
  },
};
</script>
