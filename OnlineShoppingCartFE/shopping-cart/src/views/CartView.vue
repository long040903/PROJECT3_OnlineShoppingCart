<template>
    <div class="home">
      <Cart />
    </div>
  </template>
  
  <script>
  import Cart from '@/components/CartComponents.vue';
  
  export default {
    name: 'CartView',
      components: {
        Cart
      }
  }
  </script>
  
  <style>
  /* Your styles here */
  </style>
  