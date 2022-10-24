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
          <el-button
            @click="handleRemoveBasketProduct"
            :disabled="loading"
            color="black"
            plain
            ><span
              v-show="loading"
              class="spinner-border spinner-border-sm"
            ></span
            ><span
              ><font-awesome-icon icon="fa-trash-can" />Remove</span
            ></el-button
          >
        </div>
      </div>
    </div>
    <div class="_price_container">
      <p>
        <span class="_font">{{ basketProduct.price }} </span>lei
      </p>
      <div class="_quantity_container">
        <button @click.prevent="handleDecrementQuantity"> - </button>
        <p>{{ basketProduct.quantity }}</p>
        <a @click.prevent="handleIncrementQuantity">+</a>
      </div>
    </div>
  </div>
</template>

<script>
import { useToast } from "vue-toastification";
export default {
  props: {
    basketProduct: {
      type: Object,
      required: true,
    },
  },
  data() {
    return {
      loading: false,
    };
  },
  setup() {
    const toast = useToast();
    return { toast };
  },
  methods: {
    handleRemoveBasketProduct() {
      this.loading = true;
      this.$store.dispatch(
        "basket/removeBasketProductEvent",
        this.basketProduct.id
      );
      this.toast.success("The item was removed!");
    },
    handleDecrementQuantity(){
      this.$store.dispatch("basket/decreaseQuantityForBasketProduct", {
      productid: this.basketProduct.id,
      quantity: this.basketProduct.quantity-1,
    })
    },
    handleIncrementQuantity(){
      this.$store.dispatch("basket/increaseQuantityForBasketProduct", {
      productid: this.basketProduct.id,
      quantity: this.basketProduct.quantity+1,
    })
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
  margin-left: 10px;
  margin-bottom: 10px;
}
._information_container h6 {
  font-size: large;
  font-weight: bold;
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
._font {
  font-family: "Monaco", Courier, monospace;
  font-weight: bolder;
  color: black;
}
._quantity_container{
  display: flex;
  justify-content: center;
  gap: 10px;
  cursor: pointer;
  }

</style>
