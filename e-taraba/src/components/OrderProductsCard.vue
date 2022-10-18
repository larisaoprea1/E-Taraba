<template>
  <div class="container">
    <div class="_image_container">
        <h5>x {{orderProduct.quantity}} - {{orderProduct.product.price}}lei /item</h5>
      <img
        :src="orderProduct.product.productPhoto"
        :alt="orderProduct.product.name"
      />
      <p>{{orderProduct.product.name}}</p>
      <p>Total price: {{orderProduct.price}}lei</p>
    </div>
  </div>
</template>
<script>
export default {
  props: {
    orderProduct: {
      type: Object,
      required: true,
    },
  },
};
</script>
<style scoped>
._image_container img{
width: 100%;
}
._image_container{
    width: 150px;
}
</style>
