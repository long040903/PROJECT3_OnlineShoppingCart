<template>
    <div class="home">
      <CreateCategory />
    </div>
  </template>
  
  <script>
  import CreateCategory from '@/components/admin/CreateCategory.vue';
  
  export default {
    name: 'CreateCategoryView',
      components: {
        CreateCategory
      }
  }
  </script>
  
  <style>
  /* Your styles here */
  </style>
  