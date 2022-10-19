<template>
<div class="_product_container ">
        <h5>x {{productToOrder.quantity}} - {{productToOrder.product.price}}lei /item</h5>
      <img
        :src="productToOrder.product.productPhoto"
        :alt="productToOrder.product.name"
      />
      <p>{{productToOrder.product.name}}</p>
      <p>Total price: {{productToOrder.price}}lei</p>
      <hr/>
    </div>
</template>

<script>
export default{
    props: {
    productToOrder: {
      type: Object,
      required: true,
    },
  },
}

</script>

<style scoped>
._product_container img{
width: 100px
}
._product_container{
    width: 100%;
}
</style>