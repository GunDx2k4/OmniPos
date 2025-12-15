<script setup lang="ts">
  import { RouterView } from 'vue-router'
  import LayoutHeader from '@/components/layout/LayoutHeader.vue'
</script>

<template>
  <div id="app">
    <div class="fixed top-0 left-0 right-0 z-50">
      <LayoutHeader />
    </div>

    <main class="pt-16 min-h-screen">
      <RouterView />
    </main>
  </div>
</template>
