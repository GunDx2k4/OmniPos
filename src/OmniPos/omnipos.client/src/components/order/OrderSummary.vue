<script setup lang="ts">
import { useOrder } from '@/composables/useOrder'
import { formatCurrency } from '@/utils/formatters'
import OrderItem from './OrderItem.vue'

const { 
  orderState, 
  increaseQty, 
  decreaseQty, 
  removeItem, 
  totalAmount 
} = useOrder();

</script>

<template>
  <div class="h-full flex flex-col bg-surface border-l border-border shadow-xl w-full md:w-87.5 lg:w-100">
    
    <div class="p-4 border-b border-border bg-primary/5 flex justify-between items-center">
      <h2 class="font-bold text-primary text-lg flex items-center gap-2">
        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="w-6 h-6 text-primary">
          <path stroke-linecap="round" stroke-linejoin="round" d="M15.75 10.5V6a3.75 3.75 0 10-7.5 0v4.5m11.356-1.993l1.263 12c.07.665-.45 1.243-1.119 1.243H4.25a1.125 1.125 0 01-1.12-1.243l1.264-12A1.125 1.125 0 015.513 7.5h12.974c.576 0 1.059.435 1.119 1.007zM8.625 10.5a.375.375 0 11-.75 0 .375.375 0 01.75 0zm7.5 0a.375.375 0 11-.75 0 .375.375 0 01.75 0z" />
        </svg>
        Đơn hàng hiện tại
      </h2>
      <span class="bg-primary/10 text-primary text-xs font-bold px-2 py-1 rounded-full">
        {{ orderState.items.length }} món
      </span>
    </div>

    <div class="flex-1 overflow-y-auto">
      
      <div v-if="orderState.items.length > 0">
        <OrderItem 
          v-for="item in orderState.items" 
          :key="item.productId"
          :item="item"
          @increase="increaseQty(item.productId)"
          @decrease="decreaseQty(item.productId)"
          @remove="removeItem(item.productId)"
        />
      </div>

      <div v-else class="h-full flex flex-col items-center justify-center text-text-muted p-8">
        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1" stroke="currentColor" class="w-16 h-16 mb-3 opacity-60 text-primary/40">
          <path stroke-linecap="round" stroke-linejoin="round" d="M2.25 3h1.386c.51 0 .955.343 1.087.835l.383 1.437M7.5 14.25a3 3 0 00-3 3h15.75m-12.75-3h11.218c1.121-2.3 2.1-4.684 2.924-7.138a60.114 60.114 0 00-16.536-1.84M7.5 14.25L5.106 5.272M6 20.25a.75.75 0 11-1.5 0 .75.75 0 011.5 0zm12.75 0a.75.75 0 11-1.5 0 .75.75 0 011.5 0z" />
        </svg>
        <p>Chưa có món nào</p>
        <p class="text-sm mt-1 text-text-muted">Vui lòng chọn từ thực đơn</p>
      </div>
    </div>

    <div class="p-4 border-t border-border bg-primary/5">
      
      <div class="flex justify-between items-center mb-4">
        <span class="text-text-muted">Tổng cộng</span>
        <span class="text-xl font-bold text-primary">
          {{ formatCurrency(totalAmount) }}
        </span>
      </div>

      <button 
        class="w-full py-3 px-4 bg-primary hover:bg-primary-hover disabled:bg-border disabled:cursor-not-allowed text-white font-bold rounded-xl transition shadow-lg flex justify-center items-center gap-2"
        :disabled="orderState.items.length === 0"
      >
        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="2" stroke="currentColor" class="w-5 h-5">
          <path stroke-linecap="round" stroke-linejoin="round" d="M2.25 8.25h19.5M2.25 9h19.5m-16.5 5.25h6m-6 2.25h3m-3.75 3h15a2.25 2.25 0 002.25-2.25V6.75A2.25 2.25 0 0019.5 4.5h-15a2.25 2.25 0 00-2.25 2.25v10.5A2.25 2.25 0 004.5 19.5z" />
        </svg>
        Thanh toán
      </button>
    </div>

  </div>
</template>