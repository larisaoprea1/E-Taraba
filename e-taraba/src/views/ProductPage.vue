<template>
  <div v-if="product">
    <img :src="product.productPhoto" />
    <h5>{{ product.name }}</h5>
    <p>{{ product.description }}</p>
  </div>
</template>

<script>
export default {
  props: ['id'],
  created() {
    this.$store.dispatch("product/fetchProduct", this.id)
  },
  computed:{
    product(){
        return this.$store.state.product.product
    }
  }
};
</script>
