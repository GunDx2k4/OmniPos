<script setup lang="ts">
import { onMounted } from 'vue'
import MenuList from '@/components/menu/MenuList.vue'
import OrderSummary from '@/components/order/OrderSummary.vue'
import { useProduct } from '@/composables/useProduct'

const { products, isLoading, error, fetchProducts } = useProduct()

onMounted(() => {
  fetchProducts()
})

const handleCheckoutSuccess = () => {
  fetchProducts()
}
</script>

<template>
  <div class="flex h-full bg-surface overflow-hidden">

    <main class="flex-1 flex flex-col h-full overflow-hidden relative">
      <div class="flex-1 overflow-y-auto p-4 md:p-6 custom-scrollbar">
        
        <div class="mb-6">
          <h1 class="text-2xl text-primary font-bold">Bán hàng</h1>
          <p class="text-text-muted text-sm mt-1">Chọn món để thêm vào đơn hàng</p>
        </div>

        <div v-if="isLoading" class="text-center py-10">
           <p class="text-text-muted">Đang tải dữ liệu...</p>
        </div>

        <div v-else-if="error" class="bg-red-50 text-red-500 p-4 rounded-lg text-center">
          {{ error }}
          <button @click="fetchProducts()" class="underline ml-2">Thử lại</button>
        </div>

        <MenuList v-else :products="products" :is-loading="isLoading" />
      </div>
    </main>

    <OrderSummary @checkout-success="handleCheckoutSuccess" />

  </div>
</template>