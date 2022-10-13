<template>
  <div class="d-flex mt-4">
    <div class="d-flex _container">
      <div class="_img_container ml-4">
        <router-link
          class="__link"
          :to="{
            name: 'ProductPage',
            params: { id: basketProduct.product.id },
          }"
        >
          <img
            :src="basketProduct.product.productPhoto"
            :alt="basketProduct.product.name"
          />
        </router-link>
      </div>
      <div class="d-flex _information_container">
        <div>
          <router-link
            class="__link"
            :to="{
              name: 'ProductPage',
              params: { id: basketProduct.product.id },
            }"
          >
            <h6>{{ basketProduct.product.name }}</h6>
          </router-link>
          <p>x{{ basketProduct.quantity }}</p>
        </div>
        <div>
          <a @click="handleRemoveBasketProduct" class="btn btn-dark">Remove</a>
        </div>
      </div>
    </div>
    <div class="_price_container">
      <p>{{ basketProduct.price }}</p>
    </div>
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
  methods:{
    handleRemoveBasketProduct(){
        this.$store.dispatch("basket/removeBasketProductEvent", this.basketProduct.id);
    }
  },
};
</script>
<style scoped>
._img_container {
  width: 230px;
}
._img_container img {
  width: 100%;
}
._price_container {
  width: 300px;
}
._container {
  width: 500px;
}
._information_container {
  flex-direction: column;
  justify-content: space-around;
  color: black;
}
.__link {
  text-decoration: none;
  color: black;
}
</style>
