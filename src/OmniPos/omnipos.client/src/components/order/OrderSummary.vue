<script setup lang="ts">
import { ref } from 'vue'
import { useOrder } from '@/composables/useOrder'
import { formatCurrency } from '@/utils/formatters'
import OrderItem from './OrderItem.vue'
import { ShoppingBagIcon, CreditCardIcon } from '@heroicons/vue/24/outline'
import { useToast } from '@/composables/useToast'

const selectedPaymentMethod = ref(0)

const toast = useToast()

const emit = defineEmits<{
  (e: 'checkout-success'): void
}>()

const {
  orderState,
  increaseQty,
  decreaseQty,
  updateQty,
  removeItem,
  totalAmount,
  checkOut,
  isSubmitting,
  error
} = useOrder()

const handlePayment = async () => {
  try {
    const orderId = await checkOut(selectedPaymentMethod.value)
    toast.success(`Thành công! Mã đơn: ${orderId}`)
    emit('checkout-success')
  } catch (e: any) {
    console.error('Lỗi khi thanh toán:', e)
    toast.error(`Lỗi khi thanh toán: ${e.message || 'Không xác định'}`)
  }
}
</script>

<template>
  <div class="h-full flex flex-col bg-surface border-l border-border shadow-xl w-full md:w-87.5 lg:w-100">

    <div class="p-4 border-b border-border bg-primary-lighter flex justify-between items-center shrink-0">
      <h2 class="font-bold text-primary text-lg flex items-center gap-2">
        <ShoppingBagIcon class="w-6 h-6 text-primary" />
        Đơn hàng hiện tại
      </h2>
      <span class="bg-primary text-primary-foreground text-xs font-bold px-2 py-1 rounded-full">
        {{ orderState.items.length }} món
      </span>
    </div>

    <div class="flex-1 overflow-y-auto min-h-0 custom-scrollbar">

      <div v-if="orderState.items.length > 0">
        <OrderItem v-for="item in orderState.items" :key="item.productId" :item="item"
          @increase="increaseQty(item.productId)" @decrease="decreaseQty(item.productId)"
          @update="(newQty: number) => updateQty(item.productId, newQty)" @remove="removeItem(item.productId)" />
      </div>

      <div v-else class="h-full flex flex-col items-center justify-center text-text-muted p-8">
        <ShoppingBagIcon class="w-16 h-16 mb-3 opacity-20 text-text-muted" />
        <p>Chưa có món nào</p>
        <p class="text-sm mt-1 text-text-muted">Vui lòng chọn từ thực đơn</p>
      </div>
    </div>

    <div class="p-4 border-t border-border bg-surface-secondary shrink-0">

      <div class="flex justify-between items-center mb-4">
        <span class="text-text-muted">Tổng cộng</span>
        <span class="text-xl font-bold text-primary">
          {{ formatCurrency(totalAmount) }}
        </span>
      </div>

      <button @click="handlePayment"
        class="w-full py-3 px-4 bg-primary hover:bg-primary-hover active:bg-primary-active disabled:bg-text-disabled disabled:cursor-not-allowed text-primary-foreground font-bold rounded-xl transition shadow-lg flex justify-center items-center gap-2"
        :disabled="isSubmitting || orderState.items.length === 0">
        <CreditCardIcon class="w-5 h-5" />
        <span v-if="isSubmitting">Đang xử lý...</span>
        <span v-else>Thanh toán</span>
      </button>
      <p v-if="useOrder().error.value" class="text-danger-foreground bg-danger/20 border border-danger/30 rounded px-3 py-2 mt-2 text-sm">
        {{ useOrder().error.value }}
      </p>
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
  background-color: var(--color-border-light);
  border-radius: 20px;
}

.custom-scrollbar::-webkit-scrollbar-thumb:hover {
  background-color: var(--color-border);
}
</style>