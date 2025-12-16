<script setup lang="ts">
import { ref, onMounted } from 'vue'
import type { Product } from '@/types/Product'
import MenuList from '@/components/sections/MenuList.vue'

const products = ref<Product[]>([])
const isLoading = ref(true)
const error = ref<string | null>(null)
const baseUrl = import.meta.env.VITE_API_BASE_URL || ''

const fetchProducts = async () => {
  isLoading.value = true
  error.value = null
  try {
    const response = await fetch(`${baseUrl}/api/v1/products`)
    if (!response.ok) throw new Error("Error fetching products")
    products.value = await response.json()
  } catch (err) {
    console.error(err)
    error.value = "Không thể tải menu."
  } finally {
    isLoading.value = false
  }
};

onMounted(() => fetchProducts())
</script>

<template>
  <main class="p-6">
    <h1 class="text-2xl text-primary font-bold mb-4">Thực đơn</h1>
    
    <MenuList 
      :products="products"
      :is-loading="isLoading"
    />
  </main>
</template>