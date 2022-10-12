<template>
  <div class="d-flex mt-4">
    <router-link
      :to="{ name: 'ProductPage', params: { id: basketProduct.product.id } }"
    >
      <div class="d-flex _container">
        <div class="_img_container ml-4">
          <img
            :src="basketProduct.product.productPhoto"
            :alt="basketProduct.product.name"
          />
        </div>
        <div>
          <p>{{ basketProduct.product.name }}</p>
          <h6> x{{basketProduct.quantity}}</h6>
        </div>
      </div>
    </router-link>
    <div class="_price_container"><p>{{basketProduct.price}}</p></div>
  </div>
</template>

<script>
export default {
  props: {
    basketProduct: {
      type: Object,
      required: true,
    },
  },
};
</script>
<style scoped>
._img_container {
  width: 300px;
}
._img_container img {
  width: 100%;
}
._price_container{
    width:300px;
}
._container{
    width: 500px;
}
</style>
