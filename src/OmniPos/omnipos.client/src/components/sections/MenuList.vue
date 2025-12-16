<script setup lang="ts">
import type { Product } from '@/types/Product'
import ProductCard from '@/components/sections/ProductCard.vue'

defineProps<{
  products: Product[]
  isLoading?: boolean
}>()
</script>

<template>
  <div class="w-full">

    <div v-if="isLoading" class="grid grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 gap-6">
      <div v-for="n in 8" :key="n" class="bg-surface rounded-2xl p-4 border border-border shadow-sm animate-pulse">
        <div class="h-40 w-full bg-border/50 rounded-xl mb-4"></div>
        <div class="h-4 bg-border/50 rounded w-3/4 mb-2"></div>
        <div class="h-3 bg-border/50 rounded w-1/2 mb-4"></div>
        <div class="flex justify-between items-center">
          <div class="h-5 bg-border/50 rounded w-1/3"></div>
          <div class="h-8 w-8 bg-border/50 rounded-full"></div>
        </div>
      </div>
    </div>

    <div v-else-if="products.length > 0" class="grid grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 gap-6">
      <ProductCard v-for="product in products" :key="product.id" :product="product" />
    </div>

    <div v-else class="flex flex-col items-center justify-center py-20 text-center">
      <div class="bg-border/30 p-6 rounded-full mb-4">
        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"
          class="w-10 h-10 text-text-muted">
          <path stroke-linecap="round" stroke-linejoin="round"
            d="M20.25 7.5l-.625 10.632a2.25 2.25 0 01-2.247 2.118H6.622a2.25 2.25 0 01-2.247-2.118L3.75 7.5m8.25 3.75h3.75M12 11.25h-3.75m4.5-6h2.25c.621 0 1.129.504 1.09 1.124a17.902 17.902 0 00-3.213 9.193 2.056 2.056 0 001.583 2.25 1.5 1.5 0 11-2.27 1.437 3.001 3.001 0 01-3.001-3.001 19.502 19.502 0 014.242-11.003H6.375" />
        </svg>
      </div>
      <h3 class="text-lg font-medium text-text">Không tìm thấy món nào</h3>
      <p class="text-text-muted mt-1">Hệ thống chưa có dữ liệu hoặc lỗi kết nối.</p>
    </div>

  </div>
</template>