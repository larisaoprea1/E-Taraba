<template>
  <h3 class="_title">Cart</h3>
  <div class="d-flex _container">
      <div class="row _row_gap">
    <div class="_basket_container col-12 col-md-8">
      <BasketProductCard
        v-for="basketProduct in basket"
        :key="basketProduct.id"
        :basketProduct="basketProduct"
      />
    </div>
    <div class="mt-5 _order_container col-12 col-md-4">
      <p>Livrare gratuita: <span>0,00 lei</span></p>
      <p>Total:</p>
      <el-button color="black"><router-link :to="{ name: 'OrderPage' }" class="nav-link"
        >Order now</router-link
      ></el-button>
    </div>
  </div>
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
._basket_container {
  margin-top: 20px;
  border: 1px solid rgb(204, 204, 204);
  flex-direction: column;
  border-radius: 5px;
  box-shadow: rgba(60, 64, 67, 0.3) 0px 1px 2px 0px,
    rgba(60, 64, 67, 0.15) 0px 2px 6px 2px;
}
._title {
  margin-top: 20px;
  display: flex;
justify-content: center;
  font-weight: bolder;
  font-size: xx-large;
}
._order_container{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 400px;
  height: 200px;
  border: 1px solid rgb(204, 204, 204);
  border-radius: 5px;
  box-shadow: rgba(60, 64, 67, 0.3) 0px 1px 2px 0px,
    rgba(60, 64, 67, 0.15) 0px 2px 6px 2px;
}
._container{
  justify-content: space-around;
}
._button{
  width: 30%;
}
._row_gap{
  justify-content: space-between;
}
</style>
