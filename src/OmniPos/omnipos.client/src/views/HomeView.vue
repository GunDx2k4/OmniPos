<script setup lang="ts">
import { ref, onMounted } from 'vue'
import type { Product } from '@/types/Product'
import MenuList from '@/components/menu/MenuList.vue'
import OrderSummary from '@/components/order/OrderSummary.vue'

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
  <div class="flex h-screen bg-surface overflow-hidden">
    
    <main class="flex-1 flex flex-col h-full overflow-hidden relative">
      
      <div class="flex-1 overflow-y-auto p-4 md:p-6 custom-scrollbar">
        
        <div class="mb-6">
          <h1 class="text-2xl text-primary font-bold">Bán hàng</h1>
          <p class="text-text-muted text-sm mt-1">Chọn món để thêm vào đơn hàng</p>
        </div>

        <div v-if="isLoading" class="text-center py-10">
          <p class="text-text-muted">Đang tải dữ liệu...</p>
        </div>

        <div v-else-if="error" class="bg-danger/10 text-danger p-4 rounded-lg text-center border border-danger/30">
          {{ error }}
          <button @click="fetchProducts" class="underline ml-2 hover:text-danger-hover transition-colors">Thử lại</button>
        </div>

        <MenuList 
          v-else
          :products="products"
          :is-loading="isLoading"
        />
      </div>
    </main>

    <OrderSummary />

  </div>
</template>

<style scoped>

.custom-scrollbar::-webkit-scrollbar {
  width: 6px;
}
.custom-scrollbar::-webkit-scrollbar-track {
  background: transparent;
}
.custom-scrollbar::-webkit-scrollbar-thumb {
  background-color: var(--color-border);
  border-radius: 20px;
  transition: background-color 0.3s;
}
.custom-scrollbar::-webkit-scrollbar-thumb:hover {
  background-color: var(--color-primary);
}
</style>