<template>
    <router-link class="d-flex justify-content-center __link col-lg-3 col-md-6 col-sm-6 col-12 mt-3" :to="{ name: 'ProductPage', params: { id: basketProduct.product.id } }">
        <div class="card">{{basketProduct.product.name}}</div>
    </router-link>
</template>

<script>


export default {
  props: {
    basketProduct: {
      type: Object,
      required: true,
    },
  },
};
</script>