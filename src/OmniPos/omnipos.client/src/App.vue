<script setup lang="ts">
  import { RouterView } from 'vue-router'
  import LayoutHeader from '@/components/layout/LayoutHeader.vue'
</script>

<template>
  <div id="app" class="h-screen flex flex-col bg-background text-text overflow-hidden font-sans">
    
    <div class="shrink-0 z-50">
      <LayoutHeader />
    </div>

    <main class="flex-1 relative overflow-hidden">
      <RouterView />
    </main>

  </div>
</template>