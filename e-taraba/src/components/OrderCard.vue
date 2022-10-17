<template>
  <div class="_order_container">
    <h4>Order number: {{ orderProduct.id }}</h4>
   <p> Order placed at {{orderProduct.createAt | moment("calendar")}} with the total of {{orderProduct.total}} lei.</p>
   <p>Made by {{orderProduct.firstName}} {{orderProduct.lastName}}.</p> 
  </div>
</template>

<script>
export default {
  props: {
    orderProduct: {
      type: Object,
    },
  },
};
</script>
<style scoped>
._order_container{
    margin: 10px;
    padding: 10px;
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    border: 1px solid gray;
    border-radius: 8px;
}
</style>