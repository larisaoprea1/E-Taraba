<template>
  <h1>Hello</h1>
  <div class="container">
    <div class="row">
    <ProductCard
      v-for="product in products"
      :key="product.id"
      :product="product"
    />
  </div>
</div>
</template>

<script>
import ProductCard from "../components/ProductCard.vue";

export default {
  name: "HomeView",
  components: {
    ProductCard,
  },
  created() {
    this.$store.dispatch("product/fetchProducts");
  },
  computed: {
    products() {
      console.log(this.$store.state.product.products);
      return this.$store.state.product.products;
    },
  },
};
</script>

<style>

</style>
