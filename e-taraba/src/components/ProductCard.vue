<template>
  <router-link class="d-flex justify-content-center __link col-lg-3 col-md-6 col-sm-6 col-12 mt-3" :to="{ name: 'ProductPage', params: { id: product.id } }">
    <div class="card card_style mt-2 " style="width: 16rem">
      <img :src="product.productPhoto" class="card-img-top" :alt="product.name" />
      <div class="card-body">
        <hr/>
        <h5 class="card-title">{{product.name}}</h5>
        <p class="card-text __bold">
          {{product.price}}$
        </p>
        <a href="#" class="btn btn-dark">Add to Cart</a>
      </div>
    </div>
  </router-link>
</template>

<script>
export default {
  props: {
    product: {
      type: Object,
      required: true,
    },
  },
};
</script>

<style scoped>
.card_style
{
    border: 2px solid #2d694f;
}
.card_style:hover{
    box-shadow: 0 0 5pt 2pt #2d694f;
}
.__link{
    text-decoration: none;
    color: black;
}
.__bold{
    font-weight: bold;
}
</style>
