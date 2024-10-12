<template>
    <div class="home">
      <ProductDetails />
    </div>
  </template>
  
  <script>
  import ProductDetails from '@/components/ProductDetailsComponents.vue';
  
  export default {
    name: 'ProductDetailsView',
      components: {
        ProductDetails
      }
  }
  </script>
  
  <style>
  /* Your styles here */
  </style>
  