<template>
  <h3>Cos</h3>
  <div class="d-flex">
    <div class="_basket_container">
      <BasketProductCard
        v-for="basketProduct in basket"
        :key="basketProduct.id"
        :basketProduct="basketProduct"
      />
    </div>
    <div class="mt-5">Total: </div>
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
<style scoped>
._basket_container{
  margin-left: 40px;
  margin-top: 40px;
  border: 1px solid rgb(204, 204, 204);
  flex-direction: column;
  border-radius: 5px;
  box-shadow: rgba(60, 64, 67, 0.3) 0px 1px 2px 0px, rgba(60, 64, 67, 0.15) 0px 2px 6px 2px;
}
</style>