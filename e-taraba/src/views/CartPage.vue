<template>
  <div class="_container">
    <h3 class="_title">Cart</h3>
    <div class="row d-flex _container">
      <div class="_basket_container col-md-9 col-12">
        <p v-if="basket.length === 0">
          Sorry, you didnt add any item in the cart yet! Please check our
          <router-link :to="{ name: 'home' }" class="nav-link"
            >store</router-link
          >
        </p>
        <BasketProductCard
          v-for="basketProduct in basket"
          :key="basketProduct.id"
          :basketProduct="basketProduct"
        />
        <a class="btn btn-dark" @click.prevent="handleEmptyCart">Empty Cart</a>
      </div>
      <div class="mt-5 _order_container col-md-3 col-12">
        <div class="_price_order">
          <p>Livrare gratuita:</p>
          <span>0,00 lei</span>
        </div>
        <div class="_price_order">
          <p>Total:</p>
          <span>{{ orderTotal }} lei</span>
        </div>
        <div v-if="basket.length === 0">
          <a class="btn btn-dark" color="black" @click="openBasic" >Order</a>
          <Dialog
            header="You can`t order nothing!"
            v-model:visible="displayBasic"
            :breakpoints="{ '960px': '75vw', '640px': '90vw' }"
            :style="{ width: '50vw' }"
          >
            <p>
              Sorry, you need to add products to the cart to make an
              order!
            </p>
            <template #footer>
              <Button
                label="I understand!"
                icon="pi pi-check"
                @click="closeBasic"
                class="p-button-text p-button-success"
              />
            </template>
          </Dialog>
        </div>
        <a v-else class="btn btn-dark" color="black"
          ><router-link :to="{ name: 'OrderPage' }" class="nav-link"
            >Order now</router-link
          ></a
        >
      </div>
    </div>
  </div>
</template>
<script>
import BasketProductCard from "@/components/BasketProductCard.vue";
export default {
  name: "CartPage",
  data(){
    return{
      displayBasic: false
    }
  },
  created() {
    if (this.currentUser) {
      this.$store.dispatch(
        "basket/fetchBasket",
        this.currentUser.user.BasketId
      );
    }
  },
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    },
    basket() {
      console.log(this.$store.state.basket.basket.basketProducts);
      return this.$store.state.basket.basket.basketProducts;
    },
    orderTotal() {
      if (this.basket != undefined) {
        let total = 0;
        this.basket.forEach((product) => {
          total += product.price;
        });
        return total;
      }
      return 0;
    },
  },
  methods: {
    handleEmptyCart() {
      this.$store.dispatch(
        "basket/emptyBasketProductsEvent",
        this.currentUser.user.Id
      );
    },
    openBasic() {
            this.displayBasic = true;
        },
        closeBasic() {
            this.displayBasic = false;
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
  padding: 20px;
  max-width: fit-content;
  margin-bottom: 20px;
}
._title {
  margin-top: 20px;
  display: flex;
  margin-left: 200px;
}
._order_container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 200px;
  border: 1px solid rgb(204, 204, 204);
  border-radius: 5px;
  box-shadow: rgba(60, 64, 67, 0.3) 0px 1px 2px 0px,
    rgba(60, 64, 67, 0.15) 0px 2px 6px 2px;
  padding: 20px;
}
._container {
  justify-content: space-around;
}
._button {
  width: 30%;
}
._price_order {
  display: flex;
  justify-content: space-between;
  width: 300px;
}
@media (max-width: 1260px) {
  ._price_order {
    width: auto;
  }
}
@media (max-width: 650px) {
  ._price_order {
    width: 300px;
  }
}
</style>
