<template>
    <div class="home">
      <CreateProduct />
    </div>
  </template>
  
  <script>
  import CreateProduct from '@/components/admin/CreateProduct.vue';
  
  export default {
    name: 'CreateProductView',
      components: {
        CreateProduct
      }
  }
  </script>
  
  <style>
  /* Your styles here */
  </style>
  