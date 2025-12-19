<script setup lang="ts">
import type { OrderItem } from '@/types/OrderItem'
import { formatCurrency } from '@/utils/formatters'
import { TrashIcon } from '@heroicons/vue/24/outline'

const props = defineProps<{
  item: OrderItem
}>()

const emit = defineEmits<{
  (e: 'increase'): void
  (e: 'decrease'): void
  (e: 'remove'): void
  (e: 'update', newQty: number): void
}>()

const onInputChange = (event: Event) => {
  const target = event.target as HTMLInputElement
  let val = parseInt(target.value)

  if (isNaN(val) || val < 0) val = 1

  if (val > props.item.stockQuantity) {
    val = props.item.stockQuantity
  }

  target.value = val.toString()
  emit('update', val)
}

const onFocus = (event: Event) => {
  (event.target as HTMLInputElement).select()
}

</script>

<template>
  <div
    class="flex items-start justify-between p-4 border-b border-dashed border-border hover:bg-primary/5 transition-colors group">

    <div class="flex-1 min-w-0 pr-3">
      <h4 class="text-sm font-semibold text-text leading-snug">
        {{ item.productName }}
      </h4>
      <div class="flex items-center gap-2 mt-1">
        <span class="text-xs text-text-muted">{{ formatCurrency(item.price) }}</span>

        <span v-if="item.quantity >= item.stockQuantity"
          class="text-[10px] font-bold text-danger bg-danger/10 px-1.5 rounded">
          Tối đa: {{ item.stockQuantity }}
        </span>
      </div>
    </div>

    <div class="flex flex-col items-end gap-2">

      <span class="text-sm font-bold text-text">
        {{ formatCurrency(item.price * item.quantity) }}
      </span>

      <div class="flex items-center gap-3">

        <div
          class="flex items-center justify-center rounded-full h-8 border border-primary/20 bg-primary/5 text-text shadow-inner">

          <button @click.stop="$emit('decrease')"
            class="h-8 w-8 rounded-l-full px-2 text-lg font-semibold text-primary transition-colors hover:bg-primary/10">
            -
          </button>

          <input type="number" :value="item.quantity" @change="onInputChange" @focus="onFocus"
            class="w-10 h-full text-center text-sm font-bold text-text bg-transparent outline-none border-none p-0 appearance-none no-spinners"
            min="1" :max="item.stockQuantity" />

          <button @click.stop="$emit('increase')"
            class="h-8 w-8 rounded-r-full px-2 text-lg font-semibold text-primary transition-colors hover:bg-primary/10">
            +
          </button>
        </div>

        <button @click.stop="$emit('remove')"
          class="text-text-muted hover:text-danger transition-colors p-1.5 rounded-md hover:bg-danger/10"
          title="Xóa món">
          <TrashIcon class="w-4 h-4" />
        </button>
      </div>
    </div>

  </div>
</template>

<style scoped>
.no-spinners::-webkit-outer-spin-button,
.no-spinners::-webkit-inner-spin-button {
  -webkit-appearance: none;
  margin: 0;
}
</style>