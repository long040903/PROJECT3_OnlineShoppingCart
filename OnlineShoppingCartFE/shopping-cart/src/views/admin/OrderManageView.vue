<template>
    <div class="home">
      <OrderManage />
    </div>
  </template>
  
  <script>
  import OrderManage from '@/components/admin/OrderManage.vue';
  
  export default {
    name: 'OrderManageView',
      components: {
        OrderManage
      }
  }
  </script>
  
  <style>
  /* Your styles here */
  </style>
  