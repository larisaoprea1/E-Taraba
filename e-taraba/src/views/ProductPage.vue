<template>
  <div v-if="product" class="container">
    <div class="d-flex flex-direction-column mt-4">
      <div class="image_container">
        <img :src="product.productPhoto" />
      </div>
      <div class="product_container">
        <h5 class="title">{{ product.name }}</h5>
        <p class="__price">{{ product.price }} lei</p>
        <div>
          <input
            class="_input"
            type="number"
            list="quantities"
            min="1"
            step="1"
            placeholder="1"
          />
          <datalist id="quantities">
            <option value="1" />
            <option value="2" />
            <option value="3" />
            <option value="4" />
            <option value="5" />
          </datalist>
          <br />
          <a class="btn btn-dark mt-2"
            ><font-awesome-icon icon="fa-solid fa-cart-shopping" />Add to
            Cart</a
          >
        </div>
        <div class="_icon">
          <font-awesome-icon icon="fa-credit-card" /> PLATA RAMBURS
          <font-awesome-icon icon="fa-truck" />LIVRARE & RETUR GRATUITE
          <font-awesome-icon icon="fa-calendar" /> 100 DE ZILE DREPT DE RETUR
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
export default {
  props: ["id"],
  created() {
    this.$store.dispatch("product/fetchProduct", this.id);
  },
  computed: {
    product() {
      return this.$store.state.product.product;
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
}
.image_container img {
  width: 100%;
}
.__price {
  color: #35a373;
  font-size: large;
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
  margin-top: 100px;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
}
.product_container {
  width: 400px;
  margin-top: 50px;
  margin-bottom: 50px;
  display: flex;
  justify-content: space-around;
  flex-direction: column;
}
input[type="number"] {
  width: 50px;
}
._icon{
  display: flex;
  flex-direction: column;
}
</style>
