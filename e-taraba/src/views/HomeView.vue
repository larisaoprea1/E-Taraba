<template>
  <h1>Hello</h1>
  <div class="products_card">
    <ProductCard
      v-for="product in products"
      :key="product.id"
      :product="product"
    />
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
.products_card {
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>
