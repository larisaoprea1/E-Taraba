<template><div>Basket</div> </template>
<script>
export default {
  name: "CartPage",
  created() {
    this.$store.dispatch("basket/getBasket", this.currentUser.user.BasketId);
  },
  computed: {
    basket() {
        console.log(this.$store.state.basket.basket)
      return this.$store.state.basket.basket;
    },
    currentUser() {
      return this.$store.state.auth.user;
    },
  },
};
</script>