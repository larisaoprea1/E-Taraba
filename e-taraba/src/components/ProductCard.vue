<template>
  <div
    class="d-flex justify-content-center __link col-lg-3 col-md-6 col-sm-6 col-12 mt-3"
    
  >
    <div class="card card_style mt-2" style="width: 16rem">
      <router-link :to="{ name: 'ProductPage', params: { id: product.id } }">
      <img
        :src="product.productPhoto"
        class="card-img-top"
        :alt="product.name"
        style="height: 250px"
      />
     </router-link>
            
      <div class="card-body" >
        <hr />
        <h5 class="card-title">{{ product.name }}</h5>
        <p class="card-text __bold">{{ product.price }} lei</p>
        <div v-if="currentUser" class="_container_buttons"> 
          <p v-if="product.quantity === 0"> Sorry this item is not in stock!</p>  
          <a v-else class="btn btn-dark rounded-pill _button" @click="handleAddToCart">Add to cart</a> 
          <a v-if="currentUser.user.IsAdmin" @click="handleRemoveProduct"><i class="pi pi-trash"></i></a>
        </div>
        
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    product: {
      type: Object,
      required: true,
    },
  },
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    },
  },
  methods:{
    handleRemoveProduct(){
      return this.$store.dispatch("product/removeProductEvent", this.product.id);
    },
    handleAddToCart() {
      this.$store.dispatch("basket/addProductToCartEvent", {
        userid: this.currentUser.user.Id,
        productid: this.product.id,
        count: 1,
      });
    },
  }
};
</script>

<style scoped>
.card_style:hover {
  box-shadow: rgba(54, 117, 93, 0.45) 0px 25px 20px -20px;
}
.__link {
  text-decoration: none;
  color: black;
  margin-bottom: 20px;
}
.__bold {
  font-weight: bold;
}
._container_buttons{
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 10px;
}
._button{
  width: 50%;
}
</style>
