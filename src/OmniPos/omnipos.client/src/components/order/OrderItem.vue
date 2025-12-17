<script setup lang="ts">
import type { OrderItem }from '@/types/OrderItem'
import { formatCurrency } from '@/utils/formatters'

defineProps<{
  item: OrderItem
}>()

const emit = defineEmits<{
  (e: 'increase'): void
  (e: 'decrease'): void
  (e: 'remove'): void
}>()

</script>

<template>
  <div class="group relative flex items-center gap-4 rounded-xl border border-primary/15 bg-surface p-4 shadow-sm transition-all hover:-translate-y-0.5 hover:shadow-md hover:ring-1 hover:ring-primary/30">
    <div class="absolute inset-y-0 left-0 w-1 rounded-l-xl bg-primary/80"></div>

    <div class="flex-1 min-w-0">
      <h4 class="text-sm font-semibold text-primary truncate" :title="item.productName">
        {{ item.productName }}
      </h4>
      <div class="mt-1 text-xs font-medium text-text-muted">
        {{ formatCurrency(item.price) }} / món
      </div>
    </div>

    <div class="flex items-center justify-center rounded-full border border-primary/20 bg-primary/5 text-text shadow-inner">
      <button
        @click="$emit('decrease')"
        class="h-9 w-9 rounded-l-full px-2 text-lg font-semibold text-primary transition-colors hover:bg-primary/10"
      >
        -
      </button>
      <span class="min-w-8 text-center text-sm font-bold text-primary">
        {{ item.quantity }}
      </span>
      <button
        @click="$emit('increase')"
        class="h-9 w-9 rounded-r-full px-2 text-lg font-semibold text-primary transition-colors hover:bg-primary/10"
      >
        +
      </button>
    </div>

    <div class="flex flex-col items-end gap-1 text-right">
      <span class="text-sm font-extrabold text-accent">
        {{ formatCurrency(item.price * item.quantity) }}
      </span>
      <button
        @click="$emit('remove')"
        class="flex items-center gap-1 text-xs font-medium text-text-muted transition hover:text-danger"
        title="Xóa món"
      >
        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="h-4 w-4">
          <path stroke-linecap="round" stroke-linejoin="round" d="M14.74 9l-.346 9m-4.788 0L9.26 9m9.968-3.21c.342.052.682.107 1.022.166m-1.022-.165L18.16 19.673a2.25 2.25 0 01-2.244 2.077H8.084a2.25 2.25 0 01-2.244-2.077L4.772 5.79m14.456 0a48.108 48.108 0 00-3.478-.397m-12 .562c.34-.059.68-.114 1.022-.165m0 0a48.11 48.11 0 013.478-.397m7.5 0v-.916c0-1.18-.91-2.164-2.09-2.201a51.964 51.964 0 00-3.32 0c-1.18.037-2.09 1.022-2.09 2.201v.916m7.5 0a48.667 48.667 0 00-7.5 0" />
        </svg>
        Xóa
      </button>
    </div>

  </div>
</template>