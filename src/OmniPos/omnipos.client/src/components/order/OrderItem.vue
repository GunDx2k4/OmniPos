<script setup lang="ts">
import type { OrderItem } from '@/types/OrderItem'
import { formatCurrency } from '@/utils/formatters'
import { TrashIcon } from '@heroicons/vue/24/outline'

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
  <div
    class="group relative flex items-center gap-4 rounded-xl border border-primary/15 bg-surface p-4 shadow-sm transition-all hover:-translate-y-0.5 hover:shadow-md hover:ring-1 hover:ring-primary/30">
    <div class="absolute inset-y-0 left-0 w-1 rounded-l-xl bg-primary/80"></div>

    <div class="flex-1 min-w-0">
      <h4 class="text-sm font-semibold text-primary truncate" :title="item.productName">
        {{ item.productName }}
      </h4>
      <div class="mt-1 text-xs font-medium text-text-muted">
        {{ formatCurrency(item.price) }} / món
      </div>
    </div>

    <div
      class="flex items-center justify-center rounded-full border border-primary/20 bg-primary/5 text-text shadow-inner">
      <button @click="$emit('decrease')"
        class="h-9 w-9 rounded-l-full px-2 text-lg font-semibold text-primary transition-colors hover:bg-primary/10">
        -
      </button>
      <span class="min-w-8 text-center text-sm font-bold text-primary">
        {{ item.quantity }}
      </span>
      <button @click="$emit('increase')"
        class="h-9 w-9 rounded-r-full px-2 text-lg font-semibold text-primary transition-colors hover:bg-primary/10">
        +
      </button>
    </div>

    <div class="flex flex-col items-end gap-1 text-right">
      <span class="text-sm font-extrabold text-accent">
        {{ formatCurrency(item.price * item.quantity) }}
      </span>
      <button @click="$emit('remove')"
        class="flex items-center gap-1 text-xs font-medium text-text-muted transition hover:text-danger"
        title="Xóa món">
        <TrashIcon class="w-4 h-4" />
      </button>
    </div>

  </div>
</template>