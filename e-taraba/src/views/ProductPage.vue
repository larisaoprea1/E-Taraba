<template>
  <div v-if="product" class="container">
    <div class="d-flex flex-direction-column mt-4">
      <div class="image_container">
        <Image :src="product.productPhoto" width="500" preview />
      </div>
      <div class="product_container">
        <div>
          <h5 class="title">{{ product.name }}</h5>
          <p class="__price">{{ product.price }} lei</p>
          <p>{{product.quantity}} pieces left</p>
        </div>
        <div class="__addtocart">
          <input
            class="_input"
            type="number"
            list="quantities"
            min="1"
            step="1"
            placeholder="1"
            v-model="count"
          />
          <datalist id="quantities">
            <option value="1" />
            <option value="2" />
            <option value="3" />
            <option value="4" />
            <option value="5" />
          </datalist>
          <br />
          <a @click.prevent="handleAddToCart" class="btn btn-dark mt-2"
            ><font-awesome-icon icon="fa-solid fa-cart-shopping" />Add to
            Cart</a
          >
        </div>
        <div class="_icon">
          <div><font-awesome-icon icon="fa-credit-card" /> PLATA RAMBURS</div>
          <div>
            <font-awesome-icon icon="fa-truck" />LIVRARE & RETUR GRATUITE
          </div>
          <div>
            <font-awesome-icon icon="fa-calendar" /> 100 DE ZILE DREPT DE RETUR
          </div>
        </div>
      </div>
    </div>
    <div class="__col">
      <div class="product_details"><p>Detalii produs:</p></div>

      <div>
        <h6 class="__margin">{{ product.description }}</h6>
      </div>
    </div>
  </div>
</template>

<script>
import { useToast } from "vue-toastification";
export default {
  props: ["id"],
  data() {
    return {
      count: "",
    };
  },
  setup() {
    const toast = useToast();
    return { toast };
  },
  created() {
    this.$store.dispatch("product/fetchProduct", this.id);
  },
  computed: {
    product() {
      console.log(this.$store.state.product.product);
      return this.$store.state.product.product;
    },
    currentUser() {
      return this.$store.state.auth.user;
    },
  },
  methods: {
    handleAddToCart() {
      this.$store.dispatch("basket/addProductToCartEvent", {
        userid: this.currentUser.user.Id,
        productid: this.product.id,
        count: this.count,
      });
      this.toast.success("Item added to the cart!");
    },
  },
};
</script>
<style scoped>
.title {
  font-size: xx-large;
  font-weight: bolder;
}
.image_container {
  width: 550px;
  padding: 10px;
  box-shadow: rgba(28, 107, 74, 0.45) 0px 25px 20px -20px;
}
.image_preview {
  width: 100%;
}
.__price {
  color: #35a373;
  font-size: x-large;
  font-weight: bolder;
}
.product_details {
  font-size: x-large;
  font-weight: bold;
}
.__margin {
  margin-bottom: 0;
}
.__col {
  margin-top: 50px;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}
.product_container {
  width: 600px;
  margin-bottom: 50px;
  display: flex;
  justify-content: space-between;
  flex-direction: column;
}
input[type="number"] {
  width: 50px;
}
._icon {
  display: flex;
  flex-direction: column;
  color: gray;
}
.__addtocart {
  margin-top: 150px;
}
</style>
