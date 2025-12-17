<script setup lang="ts">
import { useOrder } from '@/composables/useOrder'
import { formatCurrency } from '@/utils/formatters'
import OrderItem from './OrderItem.vue'
import { ShoppingBagIcon, CreditCardIcon } from '@heroicons/vue/24/outline'

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

    <div class="p-4 border-b border-border bg-primary/5 flex justify-between items-center shrink-0">
      <h2 class="font-bold text-primary text-lg flex items-center gap-2">
        <ShoppingBagIcon class="w-6 h-6 text-primary" />
        Đơn hàng hiện tại
      </h2>
      <span class="bg-primary/10 text-primary text-xs font-bold px-2 py-1 rounded-full">
        {{ orderState.items.length }} món
      </span>
    </div>

    <div class="flex-1 overflow-y-auto min-h-0 custom-scrollbar">

      <div v-if="orderState.items.length > 0">
        <OrderItem v-for="item in orderState.items" :key="item.productId" :item="item"
          @increase="increaseQty(item.productId)" @decrease="decreaseQty(item.productId)"
          @remove="removeItem(item.productId)" />
      </div>

      <div v-else class="h-full flex flex-col items-center justify-center text-text-muted p-8">
        <ShoppingBagIcon class="w-16 h-16 mb-3 opacity-20 text-text-muted" />
        <p>Chưa có món nào</p>
        <p class="text-sm mt-1 text-text-muted">Vui lòng chọn từ thực đơn</p>
      </div>
    </div>

    <div class="p-4 border-t border-border bg-primary/5 shrink-0">

      <div class="flex justify-between items-center mb-4">
        <span class="text-text-muted">Tổng cộng</span>
        <span class="text-xl font-bold text-primary">
          {{ formatCurrency(totalAmount) }}
        </span>
      </div>

      <button
        class="w-full py-3 px-4 bg-primary hover:bg-primary-hover disabled:bg-border disabled:cursor-not-allowed text-white font-bold rounded-xl transition shadow-lg flex justify-center items-center gap-2"
        :disabled="orderState.items.length === 0">
        <CreditCardIcon class="w-5 h-5" />
        Thanh toán
      </button>
    </div>

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
}
</style>