<template><div>Basket</div></template>
<script>
export default {
  name: "CartPage",
  created() {
    this.$store.dispatch("basket/fetchBasket", this.currentUser.user.BasketId );
  },
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    },
    basket() {
        console.log(this.$store.state.basket.basket)
        return this.$store.state.basket.basket
    },
  },
};
</script>
