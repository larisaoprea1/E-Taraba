<template>
  <div>
    <ImageSlider />
    <input v-model="searchProduct" />
    <button @click.prevent="handleSearchProduct">Search</button>
    <div class="container">
      <div class="row">
        <ProductCard
          v-for="product in products"
          :key="product.id"
          :product="product"
        />
      </div>
    </div>
  </div>
</template>

<script>
import ProductCard from "../components/ProductCard.vue";
import ImageSlider from "../components/ImageSlider.vue";

export default {
  name: "HomeView",
  components: {
    ProductCard,
    ImageSlider,
  },
  data() {
    return {
      searchProduct: "",
    };
  },
  created() {
    this.$store.dispatch("product/fetchProducts", (this.searchProduct = ""));
  },
  computed: {
    products() {
      console.log(this.$store.state.product);
      return this.$store.state.product.products;
    },
  },
  methods: {
    handleSearchProduct() {
      this.$store.dispatch("product/fetchProducts", this.searchProduct);
    },
  },
};
</script>

<style></style>
