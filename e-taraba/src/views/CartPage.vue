<template>
  <div>
    <BasketProductCard
      v-for="basketProduct in basket"
      :key="basketProduct.id"
      :basketProduct="basketProduct"
    />
  </div>
</template>
<script>
import BasketProductCard from "@/components/BasketProductCard.vue";
export default {
  name: "CartPage",
  created() {
    this.$store.dispatch("basket/fetchBasket", this.currentUser.user.BasketId);
  },
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    },
    basket() {
      console.log(this.$store.state.basket.basket.basketProduct);
      console.log(this.$store.state.basket.basket.basketProducts);
      return this.$store.state.basket.basket.basketProducts;
    },
  },
  components: { BasketProductCard },
};
</script>
